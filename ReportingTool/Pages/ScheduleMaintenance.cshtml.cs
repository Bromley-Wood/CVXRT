using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reportingtool.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public RouteCall Edit_Route_Call { get; set; }

        [BindProperty]
        public List<int> AreChecked { get; set; }

        public IList<RouteCall> Route_Call_All { get; set; }
        // Route_Call_Week_List contains four lists of route calls: last week, current week, next week and week after next
        public List<List<RouteCall>> Route_Call_Week_List = new List<List<RouteCall>>();
        public List<double> WeekHourList = new List<double>();

        public IList<VRouteMachines> V_Route_Machines_All { get; set; }

        public Dictionary<int, List<VRouteMachines>> Machine_List_Dict = new Dictionary<int, List<VRouteMachines>>();

        public CustomRouteList result  {get; set;}

        public async Task OnGetAsync()
        {
            GetUserName();

            V_Route_Machines_All = await _context.VRouteMachines
                .AsNoTracking()
                .ToListAsync();

            /* Get Route_Call for different weeks */
            Route_Call_All = await _context.RouteCall
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
                    if (! Machine_List_Dict.ContainsKey(r_id)){

                        var Machine_List = V_Route_Machines_All
                            .Where(m => m.RouteId == r_id)
                            .ToList();
                        Machine_List_Dict.Add(r_id, Machine_List);
                    }
                }
            }
            /* Get Route_Call for different weeks */
        }

        public async Task<IActionResult> OnPostEditRouteCall()
        {
            GetUserName();

            //Console.WriteLine(" ------------------------------ Edit Route Call ------------------------------");
            //Console.WriteLine(Edit_Route_Call.Schedule_Date);
            //Console.WriteLine(Edit_Route_Call.PK_CallId);

            var Updated_Route_Call = await _context.RouteCall.FirstOrDefaultAsync(m => m.PkCallId == Edit_Route_Call.PkCallId);
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

                var Updated_Route_Call = await _context.RouteCall.FirstOrDefaultAsync(m => m.PkCallId == AreChecked[i]);
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
            return _context.RouteCall.Any(e => e.PkCallId == id);
        }


        public ActionResult OnGetRouteList()
        {

            // "[\"2020-11-01T05:00:00.000Z\",\"2020-11-02T05:00:00.000Z\"]"  =>
            // 202-11-01 2020-11-02
            var date_range = Request.Query["data"].ToString().Replace("\"","").Replace("[", "").Replace("]","").Split(",");
            DateTime start_time = DateTime.ParseExact(date_range[0], "yyyy-MM-ddTHH:mm:ss.fffZ", null);
            DateTime end_time = DateTime.ParseExact(date_range[1], "yyyy-MM-ddTHH:mm:ss.fffZ", null);
            Console.WriteLine(" ------------------------------ Get custom route list------------------------------");
            Console.WriteLine("Get datetime range from {0} to {1}", start_time, end_time);
            Console.WriteLine(" ------------------------------ Get custom route list ------------------------------");
            
            /* Get Route_Call for different weeks */
            Route_Call_All =  _context.RouteCall
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => c.CompleteDate == null)
                .AsNoTracking()
                .ToList();

            List<RouteCall> Custom_Route_Call_List = Route_Call_All
                    .Where(r => r.ScheduleDate <= end_time)
                    .Where(r => r.ScheduleDate >= start_time)
                    .OrderBy(r => r.PkCallId)
                    .ToList();

            double route_hour = Custom_Route_Call_List.Sum(r => r.LabourHours);

            result = new CustomRouteList {route_list = Custom_Route_Call_List, hour = route_hour};
            
            return new JsonResult(result);
        }


    }
}
