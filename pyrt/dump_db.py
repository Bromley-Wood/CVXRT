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
from sqlalchemy import create_engine, inspect

from dotenv import load_dotenv



def get_mysql_connection():
    DB_USER = os.getenv("DB_USER")
    DB_PASSWORD = os.getenv("DB_PASSWORD")
    DB_SERVER = os.getenv("DB_SERVER")
    DB_PORT = os.getenv("DB_PORT")
    DB_SCHEMA = os.getenv("DB_SCHEMA")


    ssl_args = {'ssl_ca': "BaltimoreCyberTrustRoot.crt.pem"}
    engine = create_engine(f'mysql+mysqlconnector://{DB_USER}:{DB_PASSWORD}@{DB_SERVER}:{DB_PORT}/{DB_SCHEMA}', 
                            echo=False,
                            connect_args=ssl_args)
    
    return engine
    


def extract_mysql_db_to_csv():
    engine = get_mysql_connection()
    inspector = inspect(engine)
    for tb in inspector.get_view_names():
        print(tb)
    exit()
    with engine.connect() as connection:
        result = connection.execute("select * from Area")
        for row in result:
            print(row)
    
    exit()

    table_list = [x for x in cursor.tables()] # get all the tables

    WRITE_FREQ = 100

    for idx, tb in enumerate(table_list):
        # if tb[2] in ["Area", "Equipment", "VibMeasPt", "PVibDataColSet", "VibTrendData", 'VibWaveform']:
        # if tb[2] in ["Area", "Equipment", "VibMeasPt", "PVibDataColSet", "VibTrendData"]:
        # if tb[2] == "VibWaveform":
        if tb[2] == "Area":
            print(f"Begin extracting {tb[2]}")
            
            stuff_to_be_saved = []

            sql_statment = "SELECT * from " + tb[2]    
            # print("Executing " + sql_statment)            
            cursor.execute(sql_statment)
            columns = [column[0] for column in cursor.description]


            columns = ["DB_source"] + columns
            stuff_to_be_saved.append(",".join(columns) + "\n")
        

            num = 0
            while True:
                record = cursor.fetchone()
                if record == None:
                    if len(stuff_to_be_saved) > 0:
                        if not os.path.exists(f"output/{tb[2]}.csv"):
                            open(f"output/{tb[2]}.csv", 'w').write(''.join(stuff_to_be_saved))
                            print("Writing data to file")
                        else:
                            open(f"output/{tb[2]}.csv", 'a').write(''.join(stuff_to_be_saved))
                            print("appending data to file")
                    break
                num += 1
                if num % LOG_FREQ == 0: 
                    print(f"Extracted {num} rows")


                if tb[2] == 'VibWaveform':
                    hex_s =  "0x" + str(binascii.hexlify(record[21]).decode('utf-8'))
                    record = [str(x) for x in record[:21]] + [hex_s] + [str(x) for x in record[22:]]
                elif tb[2] in ["Area", "Equipment", "VibMeasPt", "PVibDataColset", "VibTrendData"]:
                    record = [str(x) for x in record]
                else:
                    pass
                
                record = [DB_source] + record


                stuff_to_be_saved.append(",".join(record) + "\n")

                if num == WRITE_FREQ:
                    open(f"output/{tb[2]}.csv", 'w').write(''.join(stuff_to_be_saved))
                    stuff_to_be_saved = []
                    print("Write data to file")
                elif num > WRITE_FREQ and num % WRITE_FREQ == 0:
                    open(f"output/{tb[2]}.csv", 'a').write(''.join(stuff_to_be_saved))
                    print("appending data to file")
                    stuff_to_be_saved = []
                else:
                    pass



if __name__ == "__main__":
    load_dotenv()
    extract_mysql_db_to_csv()
    

