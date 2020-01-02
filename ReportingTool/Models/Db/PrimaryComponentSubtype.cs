using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class PrimaryComponentSubtype
    {
        public int PkPrimaryComponentSubtypeId { get; set; }
        public string PrimaryComponentSubtype1 { get; set; }
        public bool PrimaryComponentSubtypeIsActive { get; set; }
        public int FkPrimaryComponentTypeId { get; set; }
    }
}
