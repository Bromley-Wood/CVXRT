using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("V_Report_Summary")]
    public class V_Report_Summary
    {
        public int FaultId { get; set; }
        public int MachineTrainId { get; set; }
        public int FaultTypeId { get; set; }
        public DateTime Create_Date { get; set; }
        public bool Fault_IsActive { get; set; }
        public string Status { get; set; }
        public string Change_In_Condition { get; set; }
        
        #nullable enable
        public int? AreaId { get; set; }
        public string? Greater_Area { get; set; }
        public string? Area { get; set; }
        public int? DrivenUnitTypeId { get; set; }
        public string? Driven_Unit_Type { get; set; }
        public string? Machine_Train { get; set; }
        public string? Machine_Train_Long_Name { get; set; }
        public string? Route { get; set; }
        public double? Cycle_Days { get; set; }
        public int? PrimaryComponentTypeId { get; set; }
        public string? Primary_Component_Type { get; set; }
        public int? PrimaryComponentSubtypeId { get; set; }
        public string? Primary_Component_Subtype { get; set; }
        public string? Fault_Type { get; set; }
        public string? Fault_Subtype { get; set; }
        public DateTime? Close_Date { get; set; }
        public string? Fault_Location { get; set; }
        public double? Production_Impact_Cost { get; set; }
        public int? ReportId { get; set; }
        [DataType(DataType.Date)] public DateTime? Report_Date { get; set; }
        [DataType(DataType.Date)] public DateTime? Measurement_Date { get; set; }
        public string? Condition { get; set; }
        public byte? Condition_Magnitude { get; set; }
        public string? Report_Type { get; set; }
        public string? Report_Stage { get; set; }
        public string? Observations { get; set; }
        public string? Actions { get; set; }
        public string? Analyst_Notes { get; set; }
        public string? External_Notes { get; set; }
        public int? Notification_No { get; set; }
        public int? Work_Order_No { get; set; }
        public string? Review_Comments { get; set; }
        public string? Analyst_Name { get; set; }
        public string? Reviewer_Name { get; set; }
        public bool? Report_IsActive { get; set; }
        public int? Condition_Difference { get; set; }
        public int? IsLatestReport { get; set; }

    }
}
