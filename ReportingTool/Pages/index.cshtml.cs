
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reportingtool.Models.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly DEV_ClientProjectContext _context;

        public IndexModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        public List<double> Route_Call_Hour_Week { get; set; }
        public int Num_Completed_Route { get; set; }
        public int Num_Machine_To_Verify { get; set; }
        public int Num_Report_In_Progress { get; set; }


        public async Task OnGetAsync()
        {
            DayOfWeek weekStart = DayOfWeek.Monday; // or Sunday, or whenever
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
            {
                startingDate = startingDate.AddDays(-1);
            }

            DateTime weekstartdate = startingDate.AddDays(0);
            DateTime weekenddate = startingDate.AddDays(6);

            Route_Call_Hour_Week = await _context.TstRouteCall
                    .Where(c => c.CompleteDate == null)
                    .Where(c => c.ScheduleDate <= weekenddate)
                    .Where(c => c.ScheduleDate >= weekstartdate)
                    .Select(c => c.LabourHours)
                    .ToListAsync();

            var VCreateReports_List = _context.VCreateReports
                .AsNoTracking()
                .ToList();

            Num_Completed_Route = VCreateReports_List
                .Select(m => m.PkCallId)
                .Distinct()
                .ToList()
                .Count;

            Num_Machine_To_Verify = VCreateReports_List
                .Count;

            Num_Report_In_Progress = _context.VTstReportSummary
                .Where(r => r.ReportStage == "In Progress")
                .AsNoTracking()
                .ToList()
                .Count;


        }




        public IActionResult OnGetSearch(string term)
        {
            var machines = new object();

            var names = _context.MachineTrain
                .Where(m => m.MachineTrain1.Contains(term))
                .Select(m => new { label = m.MachineTrain1, value = m.PkMachineTrainId })
                .ToList();
            return new JsonResult(names);
        }



    }
}