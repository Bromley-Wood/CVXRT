using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("V_Create_Reports")]
    public class V_Create_Reports
    {
        public int PK_CallId { get; set; }
        public int Call_No { get; set; }
        public double Labour_Hours { get; set; }
        [DataType(DataType.Date)] public DateTime Plan_Date { get; set; }
        [DataType(DataType.Date)] public DateTime Schedule_Date { get; set; }

        #nullable enable
        public int? PK_RouteId { get; set; }
        public string? Route { get; set; }
        public string? Module_Code { get; set; }
        public string? Unit { get; set; }
        public double? Cycle_Days { get; set; }
        public DateTime? Modified_Date { get; set; }
        public string? Modified_By { get; set; }
        public DateTime? Complete_Date { get; set; }
        public int? PK_MachineTrainId { get; set; }
        public string? Machine_Train { get; set; }
        public string? Machine_Train_Long_Name { get; set; }
        public string? Record { get; set; }
        public int? FaultId { get; set; }
        public string? Primary_Component_Type { get; set; }
        public string? Fault_Type { get; set; }
        public DateTime? Create_Date { get; set; }
        public string? Fault_Location { get; set; }
        public int? ReportId { get; set; }
        public string? Condition { get; set; }
        public string? Actions { get; set; }
        public int? Condition_Difference { get; set; }
        public string? Change_In_Condition { get; set; }
        [DataType(DataType.Date)] public DateTime? Report_Date { get; set; }
        [DataType(DataType.Date)] public DateTime? Measurement_Date { get; set; }
    }
}
