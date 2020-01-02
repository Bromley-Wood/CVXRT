using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VConditionDaily
    {
        public string MachineTrain { get; set; }
        public int MachineTrainId { get; set; }
        public int? ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? NextReportDate { get; set; }
        public byte? ConditionMagnitude { get; set; }
        public DateTime? Date { get; set; }
        public int? DateKey { get; set; }
        public byte? IsoweekOfYear { get; set; }
        public byte? Month { get; set; }
        public int? Year { get; set; }
    }
}
