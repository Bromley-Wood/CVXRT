using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class TempReports
    {
        public string GreaterArea { get; set; }
        public string Area { get; set; }
        public string DrivenUnitType { get; set; }
        public string Condition { get; set; }
        public byte? ConditionMagnitude { get; set; }
        public string Actions { get; set; }
        public string AnalystNotes { get; set; }
        public string ExternalNotes { get; set; }
        public string MachineTrain { get; set; }
        public string MachineTrainLongName { get; set; }
        public string Route { get; set; }
        public double? CycleDays { get; set; }
        public int FaultTypeId { get; set; }
        public string FaultType { get; set; }
        public bool FaultIsActive { get; set; }
        public string Status { get; set; }
        public int? ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? MeasurementDate { get; set; }
        public string ReportType { get; set; }
        public string ReportStage { get; set; }
    }
}
