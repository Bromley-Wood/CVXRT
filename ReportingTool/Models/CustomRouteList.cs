using System.Collections.Generic;
using Reportingtool.Models.Db;

namespace Reportingtool.Pages{
    public partial class CustomRouteList{
        public List<RouteCall> route_list {get; set;}
        public double hour {get; set;}
        public List<List<VRouteMachines>> machine_train_list {get; set;}
    }
}

