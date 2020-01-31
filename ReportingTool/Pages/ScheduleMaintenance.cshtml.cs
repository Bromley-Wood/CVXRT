using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reportingtool.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{
    public class ScheduleMaintenanceModel : BasePageModel
    {
        private readonly DEV_ClientProjectContext _context;

        public ScheduleMaintenanceModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TstRouteCall Edit_Route_Call { get; set; }

        [BindProperty]
        public List<int> AreChecked { get; set; }

        public IList<TstRouteCall> Route_Call_All { get; set; }
        // Route_Call_Week_List contains four lists of route calls: last week, current week, next week and week after next
        public List<List<TstRouteCall>> Route_Call_Week_List = new List<List<TstRouteCall>>();
        public List<double> WeekHourList = new List<double>();

        public IList<VRouteMachines> V_Route_Machines_All { get; set; }

        public Dictionary<int, List<VRouteMachines>> Machine_List_Dict = new Dictionary<int, List<VRouteMachines>>();


        public async Task OnGetAsync()
        {
            V_Route_Machines_All = await _context.VRouteMachines
                .AsNoTracking()
                .ToListAsync();

            /* Get Route_Call for different weeks */
            Route_Call_All = await _context.TstRouteCall
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => c.CompleteDate == null)
                .AsNoTracking()
                .ToListAsync();

            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
            {
                startingDate = startingDate.AddDays(-1);
            }


            for (int i = 0; i < 4; ++i)
            {

                DateTime weekstartdate = startingDate.AddDays(-7 + 7 * i);
                DateTime weekenddate = startingDate.AddDays(-1 + 7 * i);

                Route_Call_Week_List.Add(Route_Call_All
                    .Where(r => r.ScheduleDate <= weekenddate)
                    .Where(r => r.ScheduleDate >= weekstartdate)
                    //.OrderBy(r => r.RouteId)
                    .ToList());

                WeekHourList.Add(Route_Call_Week_List[i].Sum(r => r.LabourHours));

                for (int j = 0; j < Route_Call_Week_List[i].Count; ++j)
                {
                    var r_id = Route_Call_Week_List[i][j].FkRouteId;
                    var Machine_List = V_Route_Machines_All
                        .Where(m => m.RouteId == r_id)
                        .ToList();
                    Machine_List_Dict.Add(r_id, Machine_List);
                }
            }
            /* Get Route_Call for different weeks */
        }

        public async Task<IActionResult> OnPostEditRouteCall()
        {
            //Console.WriteLine(" ------------------------------ Edit Route Call ------------------------------");
            //Console.WriteLine(Edit_Route_Call.Schedule_Date);
            //Console.WriteLine(Edit_Route_Call.PK_CallId);

            var Updated_Route_Call = await _context.TstRouteCall.FirstOrDefaultAsync(m => m.PkCallId == Edit_Route_Call.PkCallId);
            Updated_Route_Call.ScheduleDate = Edit_Route_Call.ScheduleDate;
            Updated_Route_Call.ModifiedBy = Current_User;

            _context.Attach(Updated_Route_Call).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteCallExists(Edit_Route_Call.PkCallId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //Console.WriteLine(" ------------------------------ Finish Editing ------------------------------");
            return RedirectToPage("/ScheduleMaintenance");
        }



        public async Task<IActionResult> OnPostCompleteRoute()
        {
            //Console.WriteLine(" ------------------------------ Complete Route ------------------------------");
            //Console.WriteLine(AreChecked.Count);
            //AreChecked.ForEach(Console.WriteLine);
            //Console.WriteLine(" ------------------------------ Complete Route ------------------------------");


            for (int i = 0; i < AreChecked.Count; ++i)
            {

                //var updateQueryString = "UPDATE tst_Route_Call SET Complete_Date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' WHERE PK_CallId=" + AreChecked[i] + ";";
                //_context.Database.ExecuteSqlRaw(updateQueryString);

                var Updated_Route_Call = await _context.TstRouteCall.FirstOrDefaultAsync(m => m.PkCallId == AreChecked[i]);
                Updated_Route_Call.CompleteDate = DateTime.Now;
                _context.Attach(Updated_Route_Call).State = EntityState.Modified;


                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteCallExists(AreChecked[i]))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            //Console.WriteLine(" ------------------------------ Finish Editing ------------------------------");
            return RedirectToPage("/ScheduleMaintenance");
        }

        private bool RouteCallExists(int id)
        {
            return _context.TstRouteCall.Any(e => e.PkCallId == id);
        }

    }
}