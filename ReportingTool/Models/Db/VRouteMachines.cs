using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VRouteMachines
    {
        public int PkMachineTrainId { get; set; }
        public string MachineTrain { get; set; }
        public string MachineTrainLongName { get; set; }
        public string DrivenUnitType { get; set; }
        public bool MachineTrainIsActive { get; set; }
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
        public int? RouteId { get; set; }
        public string Route { get; set; }
        public string ModuleCode { get; set; }
        public string Unit { get; set; }
        public double? CycleDays { get; set; }
        public double? LabourHours { get; set; }
        public DateTime? FirstCallDate { get; set; }
        public bool? RouteIsActive { get; set; }
    }
}
