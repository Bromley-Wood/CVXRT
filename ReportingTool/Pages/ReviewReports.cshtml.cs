using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reportingtool.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Reportingtool.Pages
{
    public class ReviewReportsModel : BasePageModel
    {


        private readonly DEV_ClientProjectContext _context;

        public ReviewReportsModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        [BindProperty] public int SelectedReportId { get; set; }
        public IList<VTstReportSummary> VTstReportSummary_InProgress { get; set; }
        public IList<string> UnitReference_InProgress { get; set; }

        //------------------- Select List------------------------------------//
        public IList<Technology> Technology_List { get; set; }
        public IList<PrimaryComponentType> PrimaryComponentType_List { get; set; }
        public IList<PrimaryComponentSubtype> PrimaryComponentSubtype_List { get; set; }
        public IList<FaultType> FaultType_List { get; set; }
        public IList<FaultSubtype> FaultSubtype_List { get; set; }
        public IList<ReportType> ReportType_List { get; set; }
        public IList<Condition> Condition_List { get; set; }
        public IList<Observation> Observation_List { get; set; }
        public IList<ObservationType> ObservationType_List { get; set; }
        public IList<Models.Db.Action> Action_List { get; set; }
        //------------------- Select List------------------------------------//

        public VTstReportSummary Current_Displayed_Report { get; set; }

        [BindProperty] public TstReport Report_To_Update { get; set; }

        [BindProperty] public TstFault Fault_To_Update { get; set; }


        public List<string> selected_status_list = new List<string> { "", "selected" };
        public List<string> active_status_list = new List<string> { "", "active" };

        public List<ReportFiles> ReportFiles_All { get; set; }

        [BindProperty] public int ReportFileID_ToDelete { get; set; }

        public List<TstReport> ReportHistoryList { get; set; } 

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

            ReportType_List = await _context.ReportType
                    .AsNoTracking()
                    .ToListAsync();

            Condition_List = await _context.Condition
                .AsNoTracking()
                .ToListAsync();
            Observation_List = await _context.Observation
                .AsNoTracking()
                .ToListAsync();
            ObservationType_List = await _context.ObservationType
                .AsNoTracking()
                .ToListAsync();
            Action_List = await _context.Action
                .AsNoTracking()
                .ToListAsync();



            //------------------------------------------------------------------//

            Report_To_Update = _context.TstReport.FirstOrDefault(r => r.PkReportId == Current_Displayed_Report.ReportId);
            Fault_To_Update = _context.TstFault.FirstOrDefault(f => f.PkFaultId == Current_Displayed_Report.FaultId);

            //------------------------------------------------------------------//

            ReportFiles_All = await _context.ReportFiles
                .Where(f => f.FkReportId == Current_Displayed_Report.ReportId)
                .AsNoTracking()
                .ToListAsync();

            //------------------------------------------------------------------//

            ReportHistoryList = await _context.TstReport
                .Where(r => r.FkFaultId == Current_Displayed_Report.FaultId)
                .Where(r => r.PkReportId != Current_Displayed_Report.ReportId)
                .Include(r => r.ReportFile_List)
                .OrderByDescending(r => r.ReportDate)
                .AsNoTracking()
                .ToListAsync();

            return Page();
        }

        public IActionResult OnPostLoadSelectedReport()
        {
            return RedirectToPage("/ReviewReports", new { id = SelectedReportId });
        }


        public async Task<IActionResult> OnPostDeleteReportFile()

        {
            Console.WriteLine("HelloHelloHelloHelloHello");
            Console.WriteLine(ReportFileID_ToDelete);
            Console.WriteLine("HelloHelloHelloHelloHello");
            var ReportFile = await _context.ReportFiles.FindAsync(ReportFileID_ToDelete);

            if (ReportFile == null)
            {
                return NotFound();
            }

            try
            {
                _context.ReportFiles.Remove(ReportFile);
                await _context.SaveChangesAsync();
                return RedirectToPage("/ReviewReports", new { id = SelectedReportId });
            }
            catch (DbUpdateException /* ex */)
            {
                throw;
            }
        }

        public async Task<IActionResult> OnPostUpdateReportFault()
        {
            Current_Displayed_Report = _context.VTstReportSummary.FirstOrDefault(r => r.ReportId == Report_To_Update.PkReportId);


            //--------------- Update Fault if FaultType is null ----------------------------//
            if (Current_Displayed_Report.FaultTypeId == null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(Fault_To_Update))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(Fault_To_Update);
                    Console.WriteLine($"{name} = {value}");
                }

                var Updated_Fault = await _context.TstFault.FirstOrDefaultAsync(f => f.PkFaultId == Fault_To_Update.PkFaultId);
                Updated_Fault.FkTechnologyId = Fault_To_Update.FkTechnologyId;
                Updated_Fault.FkPrimaryComponentTypeId = Fault_To_Update.FkPrimaryComponentTypeId;
                Updated_Fault.FkPrimaryComponentSubtypeId = Fault_To_Update.FkPrimaryComponentSubtypeId;
                Updated_Fault.FkFaultTypeId = Fault_To_Update.FkFaultTypeId;
                Updated_Fault.FkFaultSubtypeId = Fault_To_Update.FkFaultSubtypeId;
                Updated_Fault.FaultLocation = Fault_To_Update.FaultLocation;

                _context.Attach(Updated_Fault).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaultExists(Fault_To_Update.PkFaultId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            //--------------- Update Fault if FaultType is null ----------------------------//

            //--------------- Update Report----------------------------//
            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(Report_To_Update))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(Report_To_Update);
            //    Console.WriteLine($"{name} = {value}");
            //}
            var Updated_Report = await _context.TstReport.FirstOrDefaultAsync(f => f.PkReportId == Report_To_Update.PkReportId);
            Updated_Report.FkReportTypeId = Report_To_Update.FkReportTypeId;
            Updated_Report.FkConditionId = Report_To_Update.FkConditionId;
            Updated_Report.ReportDate = Report_To_Update.ReportDate;
            Updated_Report.Observations = Report_To_Update.Observations;
            Updated_Report.Actions = Report_To_Update.Actions;
            Updated_Report.ExternalNotes = Report_To_Update.ExternalNotes;
            Updated_Report.NotificationNo = Report_To_Update.NotificationNo;
            Updated_Report.WorkOrderNo = Report_To_Update.WorkOrderNo;
            Updated_Report.AnalystNotes = Report_To_Update.AnalystNotes;
            Updated_Report.FkReportStageId = Report_To_Update.FkReportStageId;

            _context.Attach(Updated_Report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(Report_To_Update.PkReportId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //--------------- Update Report----------------------------//

            //--------------- Upload Attachments----------------------------//
            var UploadFileList = HttpContext.Request.Form.Files;
            foreach (var file in UploadFileList)
            {

                ReportFiles New_ReportFile = new ReportFiles();

                Console.WriteLine(file.FileName);
                New_ReportFile.FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                New_ReportFile.FkReportId = Report_To_Update.PkReportId;
                New_ReportFile.UploadDate = DateTime.Now;
                New_ReportFile.UploadedBy = Current_User;

                _context.ReportFiles.Add(New_ReportFile);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportFileExists(New_ReportFile.PkFilePathId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                string save_path = $"wwwroot\\MachineAttach\\{New_ReportFile.FileName}";
                //string save_path = $"c:\\MachineAttach\\{New_Machine_Train_File.FileName}";
                using (var fileStream = new FileStream(save_path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            //--------------- Upload Attachments----------------------------//
            return RedirectToPage("/ReviewReports", new { id = Report_To_Update.PkReportId });
        }

        private bool FaultExists(int id)
        {
            return _context.TstFault.Any(e => e.PkFaultId == id);
        }

        private bool ReportExists(int id)
        {
            return _context.TstReport.Any(e => e.PkReportId == id);
        }

        private bool ReportFileExists(int id)
        {
            return _context.ReportFiles.Any(e => e.PkFilePathId == id);
        }


    }
}