using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Fault
    {
        public int PkFaultId { get; set; }
        public int FkMachineTrainId { get; set; }
        public int? FkPrimaryComponentTypeId { get; set; }
        public int? FkPrimaryComponentSubtypeId { get; set; }
        public int FkTechnologyId { get; set; }
        public int? FkFaultTypeId { get; set; }
        public int? FkFaultSubtypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string FaultLocation { get; set; }
        public double? ProductionImpactCost { get; set; }
        public bool FaultIsActive { get; set; }
        public string Status { get; set; }
    }
}
