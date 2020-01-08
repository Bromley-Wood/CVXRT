using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class MachineTrainFiles
    {
        public int PkFilePathId { get; set; }
        public int FkMachineTrainId { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadedBy { get; set; }
    }
}
