using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Report
    {
        public int PkReportId { get; set; }
        public int FkFaultId { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? MeasurementDate { get; set; }
        public int FkConditionId { get; set; }
        public int FkReportTypeId { get; set; }
        public int? FkReportStageId { get; set; }
        public string Observations { get; set; }
        public string Actions { get; set; }
        public string AnalystNotes { get; set; }
        public string ExternalNotes { get; set; }
        public int? NotificationNo { get; set; }
        public int? WorkOrderNo { get; set; }
        public string ReviewComments { get; set; }
        public string AnalystName { get; set; }
        public string ReviewerName { get; set; }
        public bool ReportIsActive { get; set; }

        public List<ReportFiles> ReportFile_List { get; set; }
    }
}
