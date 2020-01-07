using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VGenerateReports
    {
        public int MachineTrainId { get; set; }
        public string MachineTrain { get; set; }
        public string MachineTrainLongName { get; set; }
        public int? DrivenUnitTypeId { get; set; }
        public string DrivenUnitType { get; set; }
        public int? RouteId { get; set; }
        public string Route { get; set; }
        public string ModuleCode { get; set; }
        public string Unit { get; set; }
        public double? CycleDays { get; set; }
        public double? LabourHours { get; set; }
        public DateTime? FirstCallDate { get; set; }
        public int? AreaId { get; set; }
        public string GreaterArea { get; set; }
        public string UnitReference { get; set; }
        public string Area { get; set; }
        public int? SiteId { get; set; }
        public string Site { get; set; }
        public bool MachineTrainIsActive { get; set; }
        public bool? DrivenUnitTypeIsActive { get; set; }
        public bool? RouteIsActive { get; set; }
        public bool? AreaIsActive { get; set; }
        public bool? SiteIsActive { get; set; }
        public int? FaultId { get; set; }
        public int? ReportId { get; set; }
        public int? ReportInProgress { get; set; }
        public string Action { get; set; }
    }
}
