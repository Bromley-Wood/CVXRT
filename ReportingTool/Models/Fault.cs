using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("tst_Fault")]
    public class Fault
    {
        [Column("PK_FaultId")]
        [Key] public int FaultId { get; set; }

        public int FK_MachineTrainId { get; set; }
        public int FK_PrimaryComponentTypeId { get; set; }
        public int FK_TechnologyId { get; set; }
        public int FK_FaultTypeId { get; set; }
        [DataType(DataType.Date)] public DateTime Create_Date { get; set; }
        public bool Fault_IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] public string Status { get; set; }

        public ICollection<Report> Report_List { get; set; }

        #nullable enable
        public int? FK_PrimaryComponentSubtypeId { get; set; }
        public int? FK_FaultSubtypeId { get; set; }
        [DataType(DataType.Date)] public DateTime? Close_Date { get; set; }
        public string? Fault_Location { get; set; }
        public double? Production_Impact_Cost { get; set; }
    }
}
