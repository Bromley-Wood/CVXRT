using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Area")]
    public class Area
    {
        [Key] 
        public int PK_AreaId { get; set; }
        [Column("Area")]
        public string AreaDescription { get; set; }
        public string Greater_Area { get; set; }
        public bool Area_IsActive { get; set; }
        public int FK_SiteId { get; set; }
        #nullable enable
        public string? Unit_Reference { get; set; }
    }
}
