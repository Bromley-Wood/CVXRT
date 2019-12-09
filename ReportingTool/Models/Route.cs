using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Route")]
    public class Route
    {
        [Key]
        [Column("PK_RouteId")]
        public int RouteId { get; set; }
        [Column("Route")]
        public string RouteDescription { get; set; }
        public int FK_AreaId { get; set; }
        public bool Route_IsActive { get; set; }

        public ICollection<Machine_Train> Machine_Train_List { get; set; }

        #nullable enable
        public string? Module_Code { get; set; }
        public string? Unit { get; set; }
        public double? Cycle_Days { get; set; }
        public double? Labour_Hours { get; set; }

        [DataType(DataType.Date)] 
        public Nullable<DateTime> First_Call_Date { get; set; }

        
        


    }
}
