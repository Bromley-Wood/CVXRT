using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class Observation
    {
        public int PkObservationId { get; set; }
        public string Observation1 { get; set; }
        public int FkObservationTypeId { get; set; }
    }
}
