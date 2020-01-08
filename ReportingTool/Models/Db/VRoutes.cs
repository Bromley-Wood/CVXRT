using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VRoutes
    {
        public int? PkRouteId { get; set; }
        public string Route { get; set; }
        public string ModuleCode { get; set; }
        public string Unit { get; set; }
        public double? CycleDays { get; set; }
        public int PkCallId { get; set; }
        public int? CallNo { get; set; }
        public int? NoMachinesOnRoute { get; set; }
        public double? LabourHours { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
