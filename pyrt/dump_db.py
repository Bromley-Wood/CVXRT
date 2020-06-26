'''


**************************
Using pyodbc 32bit version
set CONDA_FORCE_32BIT=1
conda crteate -n py27_32 python=2.7
pip install pyodbc

set CONDA_FORCE_32BIT=1
conda activate py27_32
**************************

**************************
MHM must be running when extracting data (YOU DON"T NEED A DONGLE TO RUN MHM SERVICE)
**************************

'''


import pyodbc
import csv
import binascii
import struct
import os

import pandas as pd 
import pyodbc
    

def save_to_file(file_name, file_mode,  stuff_to_be_saved):
    open(file_name, file_mode).write(''.join(stuff_to_be_saved))
    if file_mode == "w":
        print(f"{len(stuff_to_be_saved)} records have been added to a new file {file_name}")
    else:
        print(f"{len(stuff_to_be_saved)} records have been appended file {file_name}")


def extract_mssql_db_to_csv():

    # TODO: use pandas write to file to avoid messing up long text columns 

    extracted_tables = [x.rstrip("\n") for x in open("extracted_tables.txt", "r").readlines()]
    
    cnxn = pyodbc.connect(r'Driver={SQL Server};Server=SVT-QLIKVIEW-D;Database=Dev_Clientproject;Trusted_Connection=yes;')
    cursor = cnxn.cursor()
    
    table_list = [x[2] for x in cursor.tables() if x[1] == "dbo"] # get all the tables

    WRITE_FREQ = 5000

    for idx, tb in enumerate(list(set(table_list) - set(extracted_tables))):

        csv_file_name = f"dump_db/{tb}.csv"
        print(f"Begin extracting {tb} to {csv_file_name}")
        
        stuff_to_be_saved = []

        sql_statment = "SELECT * from " + tb
        cursor.execute(sql_statment)
        columns = [column[0] for column in cursor.description]

        stuff_to_be_saved.append(",".join(columns) + "\n")
    

        num = 1
        while True:
            record = cursor.fetchone()
            
            if record == None:
                if len(stuff_to_be_saved) > 0:
                    if not os.path.exists(csv_file_name):
                        save_to_file(csv_file_name, "w",  stuff_to_be_saved)
                    else:
                        save_to_file(csv_file_name, "a",  stuff_to_be_saved)
                break
            
            stuff_to_be_saved.append(",".join([str(x) for x in record]) + "\n")

            if num % WRITE_FREQ == 0:
                if not os.path.exists(csv_file_name):
                    save_to_file(csv_file_name, "w",  stuff_to_be_saved)    
                else:
                    save_to_file(csv_file_name, "a",  stuff_to_be_saved)    

                stuff_to_be_saved = []
            
            num += 1
            
            
                
            



if __name__ == "__main__":
    extract_mssql_db_to_csv()
    

