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

        // This part should read from the database later.
        public IList<string> MachineNames = new string[] {
            "0A-0920-K1A", "0A-0920-K1B", "0A-0920-K1A", "0A-0920-K1B", "0A-0960-K1A", "0A-0960-K1B", "0A-0990-K1A", "0A-0990-K1B", "0A-0990-K1C", "0E-0912-K1", "0E-0912-K2", "0E-0914-K1", "0E-0914-K2", "0E-0920-K1", "0E-0920-K2", "0E-0952-K1", "0E-0952-K2", "0E-0960-K1", "0E-0960-K2", "0E-0980-K1", "0E-0980-K2", "0E-0990-K1", "0E-0990-K2", "0E-0990-K3", "0E-0990-K4", "0E-0991-K1", "0E-0991-K2", "0K-0980-K1A", "0K-0980-K1B", "1E-0911-K1", "1E-0911-K2", "1E-0911-K3", "1E-0911-K4", "1E-0911-K5", "1E-0911-K6", "1E-0951-K1", "1E-0951-K2", "1P-0901A-K1", "1P-0901A-K2", "1P-0901B-K1", "1P-0901B-K2", "1P-0910A-K1", "1P-0910B-K1", "1P-0950A-K1", "1P-0950B-K1", "2E-0911-K1", "2E-0911-K2", "2E-0911-K3", "2E-0911-K4", "2E-0911-K5", "2E-0911-K6", "2E-0951-K1", "2E-0951-K2", "2P-0901A-K1", "2P-0901A-K2", "2P-0901B-K1", "2P-0901B-K2", "2P-0910A-K1", "2P-0910B-K1", "2P-0950A-K1", "2P-0950B-K1"        };
        public async Task OnGetAsync()
        {
            //Route_Call = await _context.Route_Call
            //    .Include(c => c.Route)
            //    .AsNoTracking()
            //    .ToListAsync();
        }

        
        
    }
}