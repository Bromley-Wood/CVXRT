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
    public class ScheduleMaintenanceModel : PageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public ScheduleMaintenanceModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Route_Call> Route_Call_All { get; set; }
        // Route_Call_Week_List contains four lists of route calls: last week, current week, next week and week after next
        public List<List<Route_Call>> Route_Call_Week_List = new List<List<Route_Call>>();
        public List<double> WeekHourList = new List<double>();

        public IList<Machine_Train> Machine_Train_All { get; set; }

        public IList<V_Route_Machines> V_Route_Machines_All { get; set; }

        public Dictionary<int, List<V_Route_Machines>> Machine_List_Dict = new Dictionary<int, List<V_Route_Machines>>();


        public async Task OnGetAsync()
        {

            V_Route_Machines_All = await _context.V_Route_Machines
                .AsNoTracking()
                .ToListAsync();

            Machine_Train_All = await _context.Machine_Train
                .AsNoTracking()
                .ToListAsync();

            /* Get Route_Call for different weeks */
            Route_Call_All = await _context.Route_Call
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .AsNoTracking()
                .ToListAsync();

            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            for (int i = 0; i < 4; ++i)
            {

                DateTime weekstartdate = startingDate.AddDays(-7 + 7 * i);
                DateTime weekenddate = startingDate.AddDays(-1 + 7 * i);

                Route_Call_Week_List.Add(Route_Call_All
                    .Where(r => r.Schedule_Date <= weekenddate)
                    .Where(r => r.Schedule_Date >= weekstartdate)
                    //.OrderBy(r => r.RouteId)
                    .ToList());

                WeekHourList.Add(Route_Call_Week_List[i].Sum(r => r.Labour_Hours));

                for (int j = 0; j < Route_Call_Week_List[i].Count; ++j)
                {
                    var r_id = Route_Call_Week_List[i][j].RouteId;
                    var Machine_List = V_Route_Machines_All
                        .Where(m => m.RouteId == r_id)
                        .ToList();
                    Machine_List_Dict.Add(r_id, Machine_List);
                }
            }

            /* Get Route_Call for different weeks */


        }




    }
}