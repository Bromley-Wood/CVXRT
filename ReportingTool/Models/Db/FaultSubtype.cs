using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class FaultSubtype
    {
        public int PkFaultSubtypeId { get; set; }
        public string FaultSubtype1 { get; set; }
        public int FkFaultTypeId { get; set; }
    }
}
