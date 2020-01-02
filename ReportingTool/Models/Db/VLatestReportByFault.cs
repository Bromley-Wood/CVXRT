using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class VLatestReportByFault
    {
        public int FkFaultId { get; set; }
        public DateTime? LatestReportDateByFault { get; set; }
        public int IsLatestReport { get; set; }
        public string Status { get; set; }
    }
}
