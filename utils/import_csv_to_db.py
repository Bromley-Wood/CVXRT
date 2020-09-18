
"""
-- delete all the data
delete from [cvxrt_wsds].[dbo].[Area];
-- reset the counter of the primary key
DBCC CHECKIDENT(Area, RESEED, 0); 
-- import csv 
...
"""

import pandas as pd 
import os 
import sqlalchemy
import urllib


if __name__ == "__main__":
    TABLE_TO_IMPORT = ["Area", "Machine_Train", "Route", "Route_Call", "Report"]
    TABLE_TO_IMPORT = ["Route", "Route_Call"]

    CSV_FOLDER_PATH = "F:\\wood\\work\\cvxrt"

    # get odbc object to run sql query
    # con = create_engine('mssql+pyodbc://mhmuser:machinelearning2018@10.210.0.14/cvxrt_wsds?driver=SQL+Server+Native+Client+10.0')
    # cnxn = pyodbc.connect(r'Driver={SQL Server};Server=10.210.0.14;Database=cvxrt_wsds;UID=mhmuser;PWD=machinelearning2018')
    # cursor = cnxn.cursor()

    params = urllib.parse.quote_plus("Driver={SQL Server};Server=10.210.0.14;Database=cvxrt_wsds;UID=mhmuser;PWD=machinelearning2018")
    engine = sqlalchemy.create_engine("mssql+pyodbc:///?odbc_connect=%s" % params) 
    engine.connect()
    
    for t in TABLE_TO_IMPORT:
        with engine.connect() as con:
            con.execute(f'DELETE FROM {t}; DBCC CHECKIDENT({t}, RESEED, 0); ')
        csv_file_path = os.path.join(CSV_FOLDER_PATH, f"dbo.{t}.csv")
        df = pd.read_csv(csv_file_path)
        df = df.drop(columns=[df.columns[0]])
        print(df)
        df.to_sql(name=t, con=engine, index=False, if_exists='append')