using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingTool.Models
{
    public class Action
    {
        [Key]
        public int PK_ActionId { get; set; }
        [Column("Action")]
        public string ActionDescription { get; set; }
        public int FK_FaultTypeId { get; set; }
        public bool Action_IsActive { get; set; }
        public int Action_Order { get; set; }
    }
}
