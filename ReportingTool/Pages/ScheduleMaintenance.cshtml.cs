using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReportingTool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{
    public class ScheduleMaintenanceModel : PageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public ScheduleMaintenanceModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Route_Call> Route_Call { get; set; }
        public async Task OnGetAsync()
        {
            Route_Call = await _context.Route_Call
                .Include(c => c.Route)
                .AsNoTracking()
                .ToListAsync();
        }

        
        
    }
}