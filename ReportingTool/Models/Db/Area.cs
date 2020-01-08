using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Area
    {
        public int PkAreaId { get; set; }
        public string Area1 { get; set; }
        public string UnitReference { get; set; }
        public string GreaterArea { get; set; }
        public bool AreaIsActive { get; set; }
        public int FkSiteId { get; set; }
    }
}
