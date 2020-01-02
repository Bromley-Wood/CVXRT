using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class MachineTrainNotes
    {
        public int PkMachineTrainNoteId { get; set; }
        public string MachineTrainNote { get; set; }
        public DateTime NoteDate { get; set; }
        public bool MachineTrainNoteIsActive { get; set; }
        public int FkMachineTrainId { get; set; }
        public bool MachineTrainNoteShowOnReport { get; set; }
        public string AnalystName { get; set; }

        //public MachineTrain Machine_Train { get; set; }
    }
}
