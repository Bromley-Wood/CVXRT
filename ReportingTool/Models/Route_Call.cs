﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Route_Call")]
    public class Route_Call
    {
        [Key] 
        public int PK_CallId { get; set; }
        public int Call_No { get; set; }
        [Column("FK_RouteId")]
        public int RouteId { get; set; }
        public double Labour_Hours { get; set; }
        public DateTime Plan_Date { get; set; }
        public DateTime Schedule_Date { get; set; }

        public Route Route { get; set; }

        [DataType(DataType.Date)] public Nullable<DateTime> Modified_Date { get; set; }
        #nullable enable 
        public string? Modified_By { get; set; }
    }
}
