using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class TstRouteCall
    {
        public int PkCallId { get; set; }
        public int CallNo { get; set; }
        public int FkRouteId { get; set; }
        public double LabourHours { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CompleteDate { get; set; }

        public Route Route { get; set; }
    }
}
