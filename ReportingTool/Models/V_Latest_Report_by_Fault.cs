using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("V_Latest_Report_by_Fault")]
    public class V_Latest_Report_by_Fault
    {
        public int FK_FaultId { get; set; }
        [DataType(DataType.Date)] public DateTime Latest_Report_Date_by_Fault { get; set; }
        public int IsLatestReport { get; set; }
    }
}
