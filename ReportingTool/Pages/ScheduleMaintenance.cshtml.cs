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

        public ICollection<Machine_Train> Machine_Train_All { get; set; }

        // This part should read from the database later.
        public IList<string> MachineNames = new string[] {
            "0A-0920-K1A", "0A-0920-K1B", "0A-0920-K1A", "0A-0920-K1B", "0A-0960-K1A", "0A-0960-K1B", "0A-0990-K1A", "0A-0990-K1B", "0A-0990-K1C", "0E-0912-K1", "0E-0912-K2", "0E-0914-K1", "0E-0914-K2", "0E-0920-K1", "0E-0920-K2", "0E-0952-K1", "0E-0952-K2", "0E-0960-K1", "0E-0960-K2", "0E-0980-K1", "0E-0980-K2", "0E-0990-K1", "0E-0990-K2", "0E-0990-K3", "0E-0990-K4", "0E-0991-K1", "0E-0991-K2", "0K-0980-K1A", "0K-0980-K1B", "1E-0911-K1", "1E-0911-K2", "1E-0911-K3", "1E-0911-K4", "1E-0911-K5", "1E-0911-K6", "1E-0951-K1", "1E-0951-K2", "1P-0901A-K1", "1P-0901A-K2", "1P-0901B-K1", "1P-0901B-K2", "1P-0910A-K1", "1P-0910B-K1", "1P-0950A-K1", "1P-0950B-K1", "2E-0911-K1", "2E-0911-K2", "2E-0911-K3", "2E-0911-K4", "2E-0911-K5", "2E-0911-K6", "2E-0951-K1", "2E-0951-K2", "2P-0901A-K1", "2P-0901A-K2", "2P-0901B-K1", "2P-0901B-K2", "2P-0910A-K1", "2P-0910B-K1", "2P-0950A-K1", "2P-0950B-K1"        };

        public async Task OnGetAsync()
        {
            //Machine_Train_All = await _context.Machine_Train
            //    .AsNoTracking()
            //    .ToListAsync();
                

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

                Console.WriteLine(weekstartdate);
                Console.WriteLine(weekenddate);

                Route_Call_Week_List.Add(Route_Call_All
                    .Where(r => r.Schedule_Date <= weekenddate)
                    .Where(r => r.Schedule_Date >= weekstartdate)
                    //.OrderBy(r => r.RouteId)
                    .ToList());

                WeekHourList.Add(Route_Call_Week_List[i].Sum(r => r.Labour_Hours));
            }
            /* Get Route_Call for different weeks */


        }



    }
}