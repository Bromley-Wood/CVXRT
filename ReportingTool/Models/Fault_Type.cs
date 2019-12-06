using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    public class Fault_Type
    {
        [Key]
        public int PK_FaultTypeId { get; set; }
        [Column("Fault_Type")]
        public string FaultType { get; set; }
        public int FK_TechnologyId { get; set; }
    }
}
