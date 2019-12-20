using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("V_Route_Machines")]
    public class V_Route_Machines
    {
        [Column("PK_MachineTrainId")] public int MachineTrainId { get; set; }
        public string Machine_Train { get; set; }
        public string Machine_Train_Long_Name { get; set; }

        public bool MachineTrain_IsActive { get; set; }

        #nullable enable
        public string? Driven_Unit_Type { get; set; }
        public int? FaultId { get; set; }
        public string? Primary_Component_Type { get; set; }
        public string? Fault_Type { get; set; }
        public DateTime? Create_Date { get; set; }
        public string? Fault_Location { get; set; }
        public int? ReportId { get; set; }
        
        [DataType(DataType.Date)] 
        public DateTime? Report_Date { get; set; }
        
        [DataType(DataType.Date)] 
        public DateTime? Measurement_Date { get; set; }
        public string? Condition { get; set; }
        public string? Actions { get; set; }
        public int? Condition_Difference { get; set; }
        public string? Change_In_Condition { get; set; }
        public int? RouteId { get; set; }
        public string? Route { get; set; }
        public string? Module_Code { get; set; }
        public string? Unit { get; set; }
        public double? Cycle_Days { get; set; }
        public double? Labour_Hours { get; set; }
        public bool? Route_IsActive { get; set; }
    }
}
