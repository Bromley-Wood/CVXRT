using System;
using System.Collections.Generic;

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
    }
}
