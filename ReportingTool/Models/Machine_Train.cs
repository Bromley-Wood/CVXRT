using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    [Table("Machine_Train")]
    public class Machine_Train
    {
        [Key] 
        public int PK_MachineTrainId { get; set; }
        [Column("Machine_Train")] public string Machine_Train_Name { get; set; }
        public string Machine_Train_Long_Name { get; set; }
        public int FK_DrivenUnitTypeId { get; set; }
        public int FK_AreaId { get; set; }
        public bool MachineTrain_IsActive { get; set; }

        #nullable enable
        [Column("FK_RouteId")] public int? RouteId { get; set; }
    }
}
