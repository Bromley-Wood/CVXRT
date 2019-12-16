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

        public IList<V_Route_Machines> V_Route_Machines_All { get; set; }

        public Dictionary<int, List<V_Route_Machines>> Machine_List_Dict = new Dictionary<int, List<V_Route_Machines>>();

        // These two lists are defined to default the first route and its table to be active
        public List<string> active_status_list = new List<string>() {"active", ""};
        public List<string> aria_selected_status_list = new List<string>() { "true", "false" };
        // These two lists are defined to default the first route and its table to be active

        public async Task OnGetAsync()
        {
            /* Get Completed Route_Call */
            Completed_Route_Call = await _context.Route_Call
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => c.Complete_Date != null)
                .AsNoTracking()
                .ToListAsync();

            V_Route_Machines_All = await _context.V_Route_Machines
                .AsNoTracking()
                .ToListAsync();


            for (int i = 0; i < Completed_Route_Call.Count; ++i)
            {
                var r_id = Completed_Route_Call[i].RouteId;
                var Machine_List = V_Route_Machines_All
                    .Where(m => m.RouteId == r_id)
                    .ToList();
                Machine_List_Dict.Add(r_id, Machine_List);
            }

        }
    }
}