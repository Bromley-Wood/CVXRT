using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Missed_Survey")]
    public class Missed_Survey
    {
        [Key]
        public int PK_MissedSurveyId { get; set; }
        public int FK_MachineTrainId { get; set; }
        public string Reason { get; set; }
        public string Reported_Missed_By { get; set; }
        #nullable enable
        public string? Comments { get; set; }
        [DataType(DataType.Date)] public DateTime? Reported_Missed_Date { get; set; }
        public int? Origin_CallId { get; set; }
    }
}
