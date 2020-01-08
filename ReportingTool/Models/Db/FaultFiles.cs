using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class FaultFiles
    {
        public int PkFilePathId { get; set; }
        public int FkFaultId { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadedBy { get; set; }
    }
}
