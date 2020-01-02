using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VTstReportSummary
    {
        public int FaultId { get; set; }
        public int? AreaId { get; set; }
        public string GreaterArea { get; set; }
        public string UnitReference { get; set; }
        public string Area { get; set; }
        public int? DrivenUnitTypeId { get; set; }
        public string DrivenUnitType { get; set; }
        public int MachineTrainId { get; set; }
        public string MachineTrain { get; set; }
        public string MachineTrainLongName { get; set; }
        public string Route { get; set; }
        public double? CycleDays { get; set; }
        public int? PrimaryComponentTypeId { get; set; }
        public string PrimaryComponentType { get; set; }
        public int? PrimaryComponentSubtypeId { get; set; }
        public string PrimaryComponentSubtype { get; set; }
        public int? FaultTypeId { get; set; }
        public string FaultType { get; set; }
        public string FaultSubtype { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string FaultLocation { get; set; }
        public double? ProductionImpactCost { get; set; }
        public bool FaultIsActive { get; set; }
        public string Status { get; set; }
        public int? ReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? MeasurementDate { get; set; }
        public string Condition { get; set; }
        public byte? ConditionMagnitude { get; set; }
        public string ReportType { get; set; }
        public string ReportStage { get; set; }
        public string Observations { get; set; }
        public string Actions { get; set; }
        public string AnalystNotes { get; set; }
        public string ExternalNotes { get; set; }
        public int? NotificationNo { get; set; }
        public int? WorkOrderNo { get; set; }
        public string ReviewComments { get; set; }
        public string AnalystName { get; set; }
        public string ReviewerName { get; set; }
        public bool? ReportIsActive { get; set; }
        public int? ConditionDifference { get; set; }
        public string ChangeInCondition { get; set; }
        public int? IsLatestReport { get; set; }
        public int? IsLastRecord { get; set; }
    }
}
