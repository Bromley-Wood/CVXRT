using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VCreateReports
    {
        public int? PkRouteId { get; set; }
        public string Route { get; set; }
        public string ModuleCode { get; set; }
        public string Unit { get; set; }
        public double? CycleDays { get; set; }
        public int PkCallId { get; set; }
        public int CallNo { get; set; }
        public double LabourHours { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int? PkMachineTrainId { get; set; }
        public string MachineTrain { get; set; }
        public string MachineTrainLongName { get; set; }
        public string Record { get; set; }
        public int? FaultId { get; set; }
        public string PrimaryComponentType { get; set; }
        public string FaultType { get; set; }
        public DateTime? CreateDate { get; set; }
        public string FaultLocation { get; set; }
        public int? ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? MeasurementDate { get; set; }
        public string Condition { get; set; }
        public string Actions { get; set; }
        public int? ConditionDifference { get; set; }
        public string ChangeInCondition { get; set; }
        public string ReportStage { get; set; }
        public string Status { get; set; }
    }
}
