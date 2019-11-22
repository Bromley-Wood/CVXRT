using System.ComponentModel.DataAnnotations;

namespace ReportingTool.Models
{
    public class Action_
    {
        [Key]
        public int PK_ActionId { get; set; }
        public string Action { get; set; }
        public int FK_FaultTypeId { get; set; }
        public bool Action_IsActive { get; set; }
        public int Action_Order { get; set; }
    }
}
