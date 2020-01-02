using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReportingTool.Models;
using Reportingtool.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Reportingtool.Pages
{
    public class ReviewReportsModel : BasePageModel
    {
        

        private readonly DEV_ClientProjectContext _context;

        public ReviewReportsModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        public IList<VTstReportSummary> VTstReportSummary_InProgress { get; set; }
        public IList<string> UnitReference_InProgress { get; set; }

        public VTstReportSummary Current_Displayed_Report { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            VTstReportSummary_InProgress = await _context.VTstReportSummary
                .Include(r => r.Machine_Train_Entry)
                    .ThenInclude(m => m.Machine_Train_Notes)
                .Where(r => r.ReportStage == "In Progress")
                .AsNoTracking()
                .ToListAsync();

            //Console.WriteLine("-----------");
            //Console.WriteLine(VTstReportSummary_InProgress.Count);
            //Console.WriteLine("-----------");

            if (VTstReportSummary_InProgress.Count == 0)
            {
                return RedirectToPage("/Noreports");
            }

            if (id == null)
            {
                id = VTstReportSummary_InProgress[0].ReportId;
                Console.WriteLine("No ID Specified. The first in progress report is displayed.");
            }

            Console.WriteLine($"Displaying report {id}");

            UnitReference_InProgress = VTstReportSummary_InProgress
                .Select(r => r.UnitReference)
                .Distinct()
                .ToList();

            Current_Displayed_Report = VTstReportSummary_InProgress.FirstOrDefault(r => r.ReportId == id);

            return Page();
        }

    }
}