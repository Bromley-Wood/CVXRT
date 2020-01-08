using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Route
    {
        public int PkRouteId { get; set; }
        public string Route1 { get; set; }
        public string ModuleCode { get; set; }
        public string Unit { get; set; }
        public double? CycleDays { get; set; }
        public double? LabourHours { get; set; }
        public DateTime? FirstCallDate { get; set; }
        public int FkAreaId { get; set; }
        public bool RouteIsActive { get; set; }
    }
}
