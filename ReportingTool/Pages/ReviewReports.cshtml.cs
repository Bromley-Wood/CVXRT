using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reportingtool.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.ComponentModel;

namespace Reportingtool.Pages
{
    public class ReviewReportsModel : BasePageModel
    {
        

        private readonly DEV_ClientProjectContext _context;

        public ReviewReportsModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int SelectedReportId { get; set; }
        public IList<VTstReportSummary> VTstReportSummary_InProgress { get; set; }
        public IList<string> UnitReference_InProgress { get; set; }
        public IList<Technology> Technology_List { get; set; }
        public IList<PrimaryComponentType> PrimaryComponentType_List { get; set; }
        public IList<PrimaryComponentSubtype> PrimaryComponentSubtype_List { get; set; }
        public IList<FaultType> FaultType_List { get; set; }
        public IList<FaultSubtype> FaultSubtype_List { get; set; }
        public VTstReportSummary Current_Displayed_Report { get; set; }
        
        [BindProperty]
        public TstReport Report_To_Update { get; set; }

        [BindProperty]
        public TstFault Fault_To_Update { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            

            VTstReportSummary_InProgress = await _context.VTstReportSummary
                .Include(r => r.Machine_Train_Entry)
                    .ThenInclude(m => m.Machine_Train_Notes)
                .Where(r => r.ReportStage == "In Progress")
                .AsNoTracking()
                .ToListAsync();

            //Console.WriteLine("-----------");

            if (VTstReportSummary_InProgress.Count == 0)
            {
                return RedirectToPage("/Noreports");
            }

            if (!(VTstReportSummary_InProgress.Select(r => r.ReportId).ToList().Contains(id)))
            {
                Console.WriteLine($"Report Not Found. The first in-progress report {VTstReportSummary_InProgress[0].ReportId} is displayed.");
                return RedirectToPage("/ReviewReports", new { id = VTstReportSummary_InProgress[0].ReportId });
            }

            Console.WriteLine($"Displaying report {id}");

            UnitReference_InProgress = VTstReportSummary_InProgress
                .Select(r => r.UnitReference)
                .Distinct()
                .ToList();

            Current_Displayed_Report = VTstReportSummary_InProgress.FirstOrDefault(r => r.ReportId == id);


            //------------------------------------------------------------------//
            Technology_List = await _context.Technology
                .AsNoTracking()
                .ToListAsync();

            PrimaryComponentType_List = await _context.PrimaryComponentType
                .AsNoTracking()
                .ToListAsync();

            PrimaryComponentSubtype_List = await _context.PrimaryComponentSubtype
                .AsNoTracking()
                .ToListAsync();

            FaultType_List = await _context.FaultType
                .AsNoTracking()
                .ToListAsync();

            FaultSubtype_List = await _context.FaultSubtype
                .AsNoTracking()
                .ToListAsync();
            //------------------------------------------------------------------//

            Report_To_Update = _context.TstReport.FirstOrDefault(r => r.PkReportId == Current_Displayed_Report.ReportId);
            Fault_To_Update = _context.TstFault.FirstOrDefault(f => f.PkFaultId == Current_Displayed_Report.FaultId);

            return Page();
        }

        public IActionResult OnPostLoadSelectedReport()
        {
            return RedirectToPage("/ReviewReports", new { id = SelectedReportId });
        }

        public async Task<IActionResult> OnPostUpdateReportFault()
        {
            //--------------- Update Fault if FaultType is null ----------------------------//
            


            foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(Fault_To_Update))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(Fault_To_Update);
                Console.WriteLine($"{name} = {value}");
            }

            return RedirectToPage("/ReviewReports");
        }

    }
}