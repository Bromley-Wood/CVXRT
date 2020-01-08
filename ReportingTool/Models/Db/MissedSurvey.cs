using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class MissedSurvey
    {
        public int PkMissedSurveyId { get; set; }
        public int FkMachineTrainId { get; set; }
        public string Reason { get; set; }
        public string Comments { get; set; }
        public DateTime? ReportedMissedDate { get; set; }
        public string ReportedMissedBy { get; set; }
        public int? OriginCallId { get; set; }
    }
}
