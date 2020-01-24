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

    public class InputReport
    {
        public int MachineTrainId { get; set; }
        public string MainOption { get; set; }
        public int Reason { get; set; }
        public string Comments { get; set; }
        public int PK_CallId { get; set; }
        public string Machine_Train_Long_Name { get; set; }
        public string RouteDescription { get; set; }
        public string Machine_Train { get; set; }

        public string Condition { get; set; }

        public string ReportStage { get; set; }
    }

    public class CreateReportsModel : BasePageModel
    {
        private readonly DEV_ClientProjectContext _context;

        public CreateReportsModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<InputReport> InputReportList { get; set; }

        public IList<TstRouteCall> Completed_Route_Call { get; set; }

        public List<int> Completed_Route_CallId { get; set; }


        public IList<VTstReportSummary> V_Report_Summary_All { get; set; }

        public IList<VCreateReports> V_Create_Reports_All { get; set; }

        public IList<TstFault> Fault_All { get; set; }

        public Dictionary<int, List<VCreateReports>> Machine_List_Dict = new Dictionary<int, List<VCreateReports>>();

        // These two lists are defined to default the first route and its table to be active
        public List<string> active_status_list = new List<string>() { "active", "" };
        public List<string> aria_selected_status_list = new List<string>() { "true", "false" };
        // These two lists are defined to default the first route and its table to be active

        public List<string> MainOptionList = new List<string>() { "missed", "good", "anomaly" };
        public IList<string> reason_list = new List<string>() { "", "No Access", "Out of Service", "Not Running" };

        public List<string> GeneratedReportSummary = new List<string>() { };

        public string log_str;

        public async Task OnGetAsync()
        {
            // This is to get what routes need to be displayed on the page
            Completed_Route_CallId = await _context.VCreateReports
                .Select(m => m.PkCallId)
                .Distinct()
                .ToListAsync();

            /* Get Completed Route_Call */
            Completed_Route_Call = await _context.TstRouteCall
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => Completed_Route_CallId.Contains(c.PkCallId))
                .AsNoTracking()
                .ToListAsync();

            V_Create_Reports_All = await _context.VCreateReports
                .AsNoTracking()
                .ToListAsync();

            for (int i = 0; i < Completed_Route_Call.Count; ++i)
            {
                var rcall_id = Completed_Route_Call[i].PkCallId;
                var Machine_List = V_Create_Reports_All
                    .Where(m => m.PkCallId == rcall_id)
                    .ToList();
                if (Machine_List.Count > 0)
                {
                    Machine_List_Dict.Add(rcall_id, Machine_List);
                }
            }

        }

        public async Task<IActionResult> OnPostCreateReport()
        {

            V_Report_Summary_All = await _context.VTstReportSummary
                .AsNoTracking()
                .ToListAsync();
            
            // only process selected machines
            InputReportList = InputReportList.Where(r => MainOptionList.Contains(r.MainOption)).ToList();

            GeneratedReportSummary.Clear();
            foreach (var inputreport in InputReportList)
            {
                Console.WriteLine("{0}--{1}--{2}--{3}--{4}",
                    inputreport.MachineTrainId, inputreport.MainOption, inputreport.Reason, inputreport.Comments, inputreport.PK_CallId);
                if (inputreport.MainOption == "missed") // Missed
                {
                    if (inputreport.Reason == 0)
                    {
                        log_str = $"Failed to create report for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in call {inputreport.RouteDescription}. You must SELECT A REASON for the missed machine!";
                        GeneratedReportSummary.Add(log_str);
                        Console.WriteLine(log_str);
                    }
                    else
                    {
                        var new_missed_sruvey = new MissedSurvey()
                        {
                            FkMachineTrainId = inputreport.MachineTrainId,
                            Reason = reason_list[inputreport.Reason],
                            Comments = inputreport.Comments,
                            ReportedMissedDate = DateTime.Now,
                            ReportedMissedBy = Current_User,
                            OriginCallId = inputreport.PK_CallId
                        };

                        _context.MissedSurvey.Add(new_missed_sruvey);
                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!FaultExists(new_missed_sruvey.PkMissedSurveyId))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        log_str = $"Missed Survey created for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in route {inputreport.RouteDescription}";
                        GeneratedReportSummary.Add(log_str);
                        Console.WriteLine(log_str);
                       
                    }
                }
                else if (inputreport.MainOption == "good") // No Action
                {

                    // -- Check 1 : Are there in progress reports?
                    var in_progress_reports_list = V_Report_Summary_All
                                                        .Where(r => r.ReportStage == "In Progress")
                                                        .Where(r => r.Status == "Open") // Case sensitive
                                                        .Where(r => r.MachineTrainId == inputreport.MachineTrainId)
                                                        .ToList();

                    if (in_progress_reports_list.Count > 0) //-- if result is not null 
                    {
                        // exit and add to warning list (tbc) (I probably need to build this in the html)
                    }
                    else //-- if result is null then there are no in progress reports.  Go to the next check (2)
                    {
                        // -- Check 2: What is the latest report for this machine?
                        VTstReportSummary latest_report = null;
                        var latest_report_list = V_Report_Summary_All
                                                .Where(r => r.MachineTrainId == inputreport.MachineTrainId)
                                                .Where(r => r.IsLatestReport == 1)
                                                .ToList();

                        foreach (var lr in latest_report_list)
                        {
                            if (lr.Condition == "No Action")
                            {
                                latest_report = lr;
                                log_str = $"Latest report has 'No Action' found for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in route {inputreport.RouteDescription}";
                                GeneratedReportSummary.Add(log_str);
                                Console.WriteLine(log_str);
                            }
                        }

                        if (latest_report != null)
                        {
                            //-- If the above returns a report that is condition 2 then raise a no action report and release it.  go to (3)
                            // Action 3
                            // --Retrieve the latest report on this machine
                            // -- Get the fault id of this report
                            // -- Create a new report on the same fault.
                            // --Set this report to no fault, routine and released
                            // --No Fault - Existing Report

                            var old_report = await _context.Report.FirstOrDefaultAsync(r => r.PkReportId == latest_report.ReportId);
                            var new_report = new TstReport()
                            {
                                FkFaultId = old_report.FkFaultId,
                                ReportDate = DateTime.Now,
                                MeasurementDate = DateTime.Now,
                                FkConditionId = 1,
                                FkReportTypeId = 1,
                                FkReportStageId = 4,
                                Observations = null,
                                Actions = null,
                                AnalystNotes = null,
                                ExternalNotes = null,
                                NotificationNo = null,
                                WorkOrderNo = null,
                                ReviewComments = null,
                                AnalystName = Current_User,
                                ReviewerName = null,
                                ReportIsActive = true,
                                OriginCallId = inputreport.PK_CallId
                            };


                            _context.TstReport.Add(new_report);
                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!FaultExists(new_report.PkReportId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            log_str = $"New report created for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in route {inputreport.RouteDescription}";
                            GeneratedReportSummary.Add(log_str);
                            Console.WriteLine(log_str);
                            

                        }
                        else
                        //-- if result is null then that means there are no open faults on this machine.  we need to raise a new fault and then a report.  go to (4).
                        {
                            // Action 4
                            // -- create a new fault on this machine
                            // -- set the fault type to no fault

                            /* Using entity framework for database operation */
                            var new_fault = new TstFault()
                            {
                                FkMachineTrainId = inputreport.MachineTrainId,
                                FkPrimaryComponentTypeId = 1,
                                FkPrimaryComponentSubtypeId = null,
                                FkTechnologyId = 1,
                                FkFaultTypeId = 1,
                                FkFaultSubtypeId = null,
                                CreateDate = DateTime.Now,
                                CloseDate = null,
                                FaultLocation = "test",
                                ProductionImpactCost = null,
                                FaultIsActive = true
                            };

                            _context.TstFault.Add(new_fault);
                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!FaultExists(new_fault.PkFaultId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            // --Create a new report on the new fault.
                            // -- Set this report to no fault, routine and released
                            var new_report = new TstReport()
                            {
                                FkFaultId = new_fault.PkFaultId,
                                ReportDate = DateTime.Now,
                                MeasurementDate = DateTime.Now,
                                FkConditionId = 1,
                                FkReportTypeId = 1,
                                FkReportStageId = 4,
                                Observations = null,
                                Actions = null,
                                AnalystNotes = null,
                                ExternalNotes = null,
                                NotificationNo = null,
                                WorkOrderNo = null,
                                ReviewComments = null,
                                AnalystName = Current_User,
                                ReviewerName = null,
                                ReportIsActive = true,
                                OriginCallId = inputreport.PK_CallId

                            };


                            _context.TstReport.Add(new_report);

                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!ReportExists(new_report.PkReportId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            log_str = $"New report created for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in route {inputreport.RouteDescription}";
                            GeneratedReportSummary.Add(log_str);
                            Console.WriteLine(log_str);
                        }
                    }
                }
                else if (inputreport.MainOption == "anomaly") // Anomaly
                {
                    log_str = $"Anomaly report hasn't been implemented for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in route {inputreport.RouteDescription}";
                    GeneratedReportSummary.Add(log_str);
                    Console.WriteLine(log_str);
                    
                }
                else
                {
                    log_str = $"Nothing changed for machine {inputreport.Machine_Train} - {inputreport.Machine_Train_Long_Name} in route {inputreport.RouteDescription}";
                    GeneratedReportSummary.Add(log_str);
                    Console.WriteLine(log_str);
                }
            }
            Console.WriteLine(GeneratedReportSummary.Count);
            return RedirectToPage("/CreateReports");
        }

        private bool FaultExists(int id)
        {
            return _context.TstFault.Any(e => e.PkFaultId == id);
        }

        private bool ReportExists(int id)
        {
            return _context.TstReport.Any(e => e.PkReportId == id);
        }
    }
}