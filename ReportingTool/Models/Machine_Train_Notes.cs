using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Machine_Train_Notes")]
    public class Machine_Train_Notes
    {
        [Key]
        public int PK_MachineTrainNoteId { get; set; }
        public string MachineTrain_Note { get; set; }
        public DateTime Note_Date { get; set; }
        public bool MachineTrainNote_IsActive { get; set; }
        [Column("FK_MachineTrainId")] public int MachineTrainId { get; set; }
        public bool MachineTrainNote_ShowOnReport { get; set; }
        public string Analyst_Name { get; set; }

    }
}
