using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    public class Machine_Train_Files
    {
        [Key] public int PK_FilePathId { get; set; }
        public int FK_MachineTrainId { get; set; }
        public string FileName { get; set; }
        public DateTime Upload_Date { get; set; }
        public string Uploaded_By { get; set; }
    }
}
