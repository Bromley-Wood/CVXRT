using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Condition
    {
        public byte PkConditionId { get; set; }
        public string Condition1 { get; set; }
        public byte ConditionMagnitude { get; set; }
        public string ConditionAltLabel { get; set; }
    }
}
