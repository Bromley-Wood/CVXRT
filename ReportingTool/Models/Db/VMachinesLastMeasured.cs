using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VMachinesLastMeasured
    {
        public string GreaterArea { get; set; }
        public string Area { get; set; }
        public string DrivenUnitType { get; set; }
        public int MachineTrainId { get; set; }
        public string MachineTrain { get; set; }
        public string MachineTrainLongName { get; set; }
        public string Route { get; set; }
        public double? CycleDays { get; set; }
        public DateTime? LatestReportDate { get; set; }
        public int? DaysSinceMeasured { get; set; }
    }
}
