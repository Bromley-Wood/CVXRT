using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReportingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{
    public class CreateReportsModel : PageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public CreateReportsModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Route_Call> Completed_Route_Call { get; set; }
        
        public async Task OnGetAsync()
        {
            /* Get Completed Route_Call */
            Completed_Route_Call = await _context.Route_Call
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => c.Complete_Date != null)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in Completed_Route_Call)
            {
                foreach (var machine in item.Route.Machine_Train_List)
                {
                    Console.WriteLine(machine.Machine_Train_Name);
                }
            }
        }
    }
}