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

    public class InputReport
    {
        public int MachineTrainId { get; set; }
        public string MainOption { get; set; }
        public int Reason { get; set; }
        public string Comments { get; set; }
        public int PK_CallId { get; set; }
        public string Machine_Train_Long_Name { get; set; }
        public string RouteDescription { get; set; }

    }

    public class CreateReportsModel : BasePageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public CreateReportsModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<InputReport> InputReportList { get; set; }

        public IList<Route_Call> Completed_Route_Call { get; set; }

        public List<int> Completed_Route_CallId { get; set; }

        //public IList<V_Route_Machines> V_Route_Machines_All { get; set; }

        public IList<V_Report_Summary> V_Report_Summary_All { get; set; }

        public IList<V_Create_Reports> V_Create_Reports_All { get; set; }

        public IList<Fault> Fault_All { get; set; }

        public Dictionary<int, List<V_Create_Reports>> Machine_List_Dict = new Dictionary<int, List<V_Create_Reports>>();

        // These two lists are defined to default the first route and its table to be active
        public List<string> active_status_list = new List<string>() {"active", ""};
        public List<string> aria_selected_status_list = new List<string>() { "true", "false" };
        // These two lists are defined to default the first route and its table to be active

        public IList<string> reason_list = new List<string>() { "", "No Access", "Out of Service", "Not Running" };

        public async Task OnGetAsync()
        {
            

            // This is to get what routes need to be displayed on the page
            Completed_Route_CallId = await _context.V_Create_Reports
                .Select(m => m.PK_CallId)
                .Distinct()
                .ToListAsync();

            /* Get Completed Route_Call */
            Completed_Route_Call = await _context.Route_Call
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => Completed_Route_CallId.Contains(c.PK_CallId))
                .AsNoTracking()
                .ToListAsync();

            V_Create_Reports_All = await _context.V_Create_Reports
                .AsNoTracking()
                .ToListAsync();

            for (int i = 0; i < Completed_Route_Call.Count; ++i)
            {
                var rcall_id = Completed_Route_Call[i].PK_CallId;
                var Machine_List = V_Create_Reports_All
                    .Where(m => m.PK_CallId == rcall_id)
                    .ToList();
                if (Machine_List.Count > 0)
                {
                    Machine_List_Dict.Add(rcall_id, Machine_List);
                }
            }

        }

        public async Task<IActionResult> OnPostCreateReport()
        {
            /* TODO
             * 1. Get the reporter's name using login info
             
             */

            V_Report_Summary_All = await _context.V_Report_Summary
                .AsNoTracking()
                .ToListAsync();
            //Console.WriteLine(V_Report_Summary_All.Count);


            //Console.WriteLine(InputReportList.Count);
            foreach (var inputreport in InputReportList)
            {

                Console.WriteLine("{0}--{1}--{2}--{3}--{4}",
                    inputreport.MachineTrainId, inputreport.MainOption, inputreport.Reason, inputreport.Comments, inputreport.PK_CallId);
                if (inputreport.MainOption == "missed") // Missed
                {
                    if (inputreport.Reason == 0)
                    {
                        Console.WriteLine("Failed to create report for machine {0} in call {1}. You must SELECT A REASON for the missed machine!", inputreport.Machine_Train_Long_Name, inputreport.RouteDescription);
                    }
                    else
                    {
                        var insertQueryString =
                        string.Format("INSERT Missed_Survey (FK_MachineTrainId, Reason, Comments, Reported_Missed_Date, Reported_Missed_By, Origin_CallId) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}); ",
                        inputreport.MachineTrainId, reason_list[inputreport.Reason], inputreport.Comments, DateTime.Now.ToString("yyyy-MM-dd"), Current_User, inputreport.PK_CallId);
                        Console.WriteLine(insertQueryString);
                        _context.Database.ExecuteSqlRaw(insertQueryString);
                    }
                }
                else if (inputreport.MainOption == "good") // No Action
                {

                    // -- Check 1 : Are there in progress reports?
                    var in_progress_reports_list = V_Report_Summary_All
                                                        .Where(r => r.Report_Stage == "In Progress")
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
                        V_Report_Summary latest_report = null;
                        var latest_report_list = V_Report_Summary_All
                                                .Where(r => r.MachineTrainId == inputreport.MachineTrainId)
                                                .Where(r => r.IsLatestReport == 1)
                                                .ToList();

                        foreach(var lr in latest_report_list)
                        {
                            if (lr.Condition == "No Action")
                            {
                                latest_report = lr;
                                Console.WriteLine("Latest report found for machine {0} in route {1}", inputreport.Machine_Train_Long_Name, inputreport.RouteDescription);
                            }
                        }

                        if (latest_report != null)
                        {
                            //-- If the above returns a report that is condition 2 then raise a no action report and release it.  go to (3)
                            
                                Console.WriteLine("Latest report has No Action");
                                // Action 3
                                // --Retrieve the latest report on this machine
                                // -- Get the fault id of this report
                                // -- Create a new report on the same fault.
                                // --Set this report to no fault, routine and released
                                // --No Fault - Existing Report
                               var insertQueryString =
                                    string.Format("INSERT INTO tst_report ([FK_FaultId] , [Report_Date], [Measurement_Date], [FK_ConditionId], [FK_ReportTypeId], [FK_ReportStageId], [Observations], [Actions], [Analyst_Notes], [External_Notes], [Notification_No], [Work_Order_No], [Review_Comments], [Analyst_Name], [Reviewer_Name], [Report_IsActive], [Origin_CallId]) SELECT [FK_FaultId],  '{0}', '{1}', 1, 1, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, {4}, NULL, 1, {2} FROM Report where [PK_ReportId] = {3};", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), inputreport.PK_CallId, latest_report.ReportId, Current_User);
                                Console.WriteLine(insertQueryString);
                                _context.Database.ExecuteSqlRaw(insertQueryString);
                            
                        }
                        else
                        //-- if result is null then that means there are no open faults on this machine.  we need to raise a new fault and then a report.  go to (4).
                        {
                            // Action 4
                            // -- create a new fault on this machine
                            // -- set the fault type to no fault

                            /* Using entity framework for database operation */
                            var new_fault = new Fault()
                            {
                                FK_MachineTrainId = inputreport.MachineTrainId,
                                FK_PrimaryComponentTypeId = 1,
                                FK_PrimaryComponentSubtypeId = null,
                                FK_TechnologyId = 1,
                                FK_FaultTypeId = 1,
                                FK_FaultSubtypeId = null,
                                Create_Date = DateTime.Now,
                                Close_Date = null,
                                Fault_Location = "test",
                                Production_Impact_Cost = null,
                                Fault_IsActive = true
                            };

                            _context.Fault.Add(new_fault);
                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!FaultExists(new_fault.FaultId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            int new_fault_id = new_fault.FaultId;
                            Console.WriteLine(new_fault_id);


                            //var insertNewFaultQuery = string.Format("INSERT INTO Fault ([FK_MachineTrainId], [FK_PrimaryComponentTypeId], [FK_PrimaryComponentSubtypeId], [FK_TechnologyId], [FK_FaultTypeId], [FK_FaultSubtypeId], [Create_Date], [Close_Date], [Fault_Location], [Production_Impact_Cost], [Fault_IsActive]) VALUES ({0}, 1, NULL, 1, 1, NULL, '{1}', NULL, NULL, NULL, 1);", inputreport.MachineTrainId, DateTime.Now.ToString("yyyy-MM-dd"));
                            //Console.WriteLine(insertNewFaultQuery);
                            // //_context.Database.ExecuteSqlRaw(insertNewFaultQuery);
                            //var newFaultId = _context.Fault.LastOrDefault().FaultId;
                            //Console.WriteLine(newFaultId);



                            // --Create a new report on the new fault.
                            // -- Set this report to no fault, routine and released
                            var new_report = new Report()
                            {
                                FaultId = new_fault_id,
                                Report_Date = DateTime.Now,
                                Measurement_Date = DateTime.Now,
                                FK_ConditionId = 1,
                                FK_ReportTypeId = 1,
                                FK_ReportStageId = 4,
                                Observations = null,
                                Actions = null,
                                Analyst_Notes = null,
                                External_Notes = null,
                                Notification_No = null,
                                Work_Order_No = null,
                                Review_Comments = null,
                                Analyst_Name = Current_User,
                                Reviewer_Name = null,
                                Report_IsActive = true,
                                Origin_CallId = inputreport.PK_CallId
                                
                            };


                            _context.Report.Add(new_report);

                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!ReportExists(new_report.PK_ReportId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            Console.WriteLine(new_fault_id);
                        }
                    }
                }
                else if (inputreport.MainOption == "anomaly") // Anomaly
                {
                    Console.WriteLine("Anomaly report hasn't been implemented");
                }
                else
                {
                    Console.WriteLine("Nothing changed For Machine {0} in Call {1}", inputreport.Machine_Train_Long_Name, inputreport.RouteDescription);
                }
            }
            return RedirectToPage("/CreateReports");
        }

        private bool FaultExists(int id)
        {
            return _context.Fault.Any(e => e.FaultId == id);
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.PK_ReportId == id);
        }
    }
}