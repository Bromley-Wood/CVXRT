using System.Collections.Generic;
using static System.Environment;

namespace ReportingTool.Models
{
    public class Action
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long FaultTypeId { get; set; }
        public bool IsActive { get; set; }
        public long Order { get; set; }
        
        public IEnumerable<string> DirectionsList
        {
            get { return (Description ?? string.Empty).Split(NewLine); }
        }
    }
}
