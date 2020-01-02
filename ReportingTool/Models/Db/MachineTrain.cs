using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reportingtool.Models.Db
{
    public partial class MachineTrain
    {
        public int PkMachineTrainId { get; set; }
        public string MachineTrain1 { get; set; }
        public string MachineTrainLongName { get; set; }
        public int FkDrivenUnitTypeId { get; set; }
        public int FkAreaId { get; set; }
        public int? FkRouteId { get; set; }
        public bool MachineTrainIsActive { get; set; }

        public IList<MachineTrainNotes> Machine_Train_Notes { get; set; }
    }
}
