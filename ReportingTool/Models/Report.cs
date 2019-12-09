using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Report")]
    public class Report
    {
        [Key] public int PK_ReportId { get; set; }
        public int FK_FaultId { get; set; }

        public int FK_ConditionId { get; set; }
        public int FK_ReportTypeId { get; set; }


        #nullable enable
        [DataType(DataType.Date)] public DateTime? Report_Date { get; set; }
        [DataType(DataType.Date)] public DateTime? Measurement_Date { get; set; }
        public int? FK_ReportStageId { get; set; }


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

    }
}
