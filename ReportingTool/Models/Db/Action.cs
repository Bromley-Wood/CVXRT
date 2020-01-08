using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Action
    {
        public int PkActionId { get; set; }
        public string Action1 { get; set; }
        public int FkFaultTypeId { get; set; }
        public bool ActionIsActive { get; set; }
        public int ActionOrder { get; set; }
    }
}
