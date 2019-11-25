using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    public class Route
    {
        [Key] 
        public int PK_RouteId { get; set; }
        [Column("Route")]
        public string RouteDescription { get; set; }
        public int FK_AreaId { get; set; }
        public bool Route_IsActive { get; set; }
        #nullable enable
        public string? Module_Code { get; set; }
        public string? Unit { get; set; }
        public double? Cycle_Days { get; set; }
        public double? Labour_Hours { get; set; }
        [DataType(DataType.Date)] 
        public Nullable<DateTime> First_Call_Date { get; set; }
        
    }
}
