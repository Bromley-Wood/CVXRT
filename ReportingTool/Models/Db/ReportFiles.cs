using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class ReportFiles
    {
        public int PkFilePathId { get; set; }
        public int FkReportId { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadedBy { get; set; }
    }
}
