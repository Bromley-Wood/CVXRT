using System.ComponentModel.DataAnnotations;

namespace ReportingTool.Models
{
    public class Fault_Type
    {
        [Key]
        public int PK_FaultTypeId { get; set; }
        public string FaultType { get; set; }
        public int FK_TechnologyId { get; set; }
    }
}
