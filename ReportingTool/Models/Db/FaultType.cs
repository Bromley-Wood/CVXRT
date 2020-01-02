using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class FaultType
    {
        public int PkFaultTypeId { get; set; }
        public string FaultType1 { get; set; }
        public int FkTechnologyId { get; set; }
    }
}
