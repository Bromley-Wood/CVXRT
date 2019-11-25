using System;
using System.ComponentModel.DataAnnotations;

namespace ReportingTool.Models
{
    public class Route_Call
    {
        [Key] public int PK_CallId { get; set; }
        public int Call_No { get; set; }
        public int FK_RouteId { get; set; }
        public double Labour_Hours { get; set; }
        public DateTime Plan_Date { get; set; }
        public DateTime Schedule_Date { get; set; }
        [DataType(DataType.Date)] public Nullable<DateTime> Modified_Date { get; set; }
        public string? Modified_By { get; set; }
    }
}
