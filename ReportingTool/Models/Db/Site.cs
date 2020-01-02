using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Site
    {
        public int PkSiteId { get; set; }
        public string Site1 { get; set; }
        public bool SiteIsActive { get; set; }
    }
}
