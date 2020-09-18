import json 
import pandas
import os 


'''
this script assigns the route id to the machines it includes
'''

DATA_FOLDER_PATH = "F:\\wood\\work\\cvxrt"

df_mt = pandas.read_csv(os.path.join(DATA_FOLDER_PATH, "dbo.Machine_Train.csv"))
df_rt = pandas.read_csv(os.path.join(DATA_FOLDER_PATH, "dbo.Route.csv"))

route_machine_f = open(os.path.join(DATA_FOLDER_PATH, "route_machine.json"), 'r')
missing_machine_f = open(os.path.join(DATA_FOLDER_PATH, "missing_machine.txt"), 'w')
missing_machine_f.write("Route, Missing_Machines\n")

data = json.load(route_machine_f)
route_list = {**data["1M"], **data["2M"]}
for route in route_list.keys():
    mt_list_csv = route_list[route] # machine list from spreadsheet
    mt_list_db = df_mt["Machine_Train"][df_mt["Machine_Train"].isin(mt_list_csv)].tolist() # machine list current in the db
    
    # this is to take note for all the machines that are currently missed in the database
    # need to back to check these machines 
    if len(mt_list_csv) > len(mt_list_db):
        missing_machine_list = list(set(mt_list_csv) - set(mt_list_db))
        # print(route, missing_machine_list)
        missing_machine_f.write(route + ", ")
        missing_machine_f.write("~".join(missing_machine_list) + "\n")

    # get the route id from the Route table
    PK_RouteId = df_rt.loc[df_rt["Route"].str.contains(route)]
    print(route, len(PK_RouteId))
    PK_RouteId = PK_RouteId["PK_RouteId"].values[0]
    df_mt.loc[df_mt["Machine_Train"].isin(mt_list_csv), "FK_RouteId"] = PK_RouteId

print(df_mt)
df_mt.to_csv("tmp.csv")
route_machine_f.close()
missing_machine_f.close()
exit()
        
    
    
    