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
        public string Status { get; set; }
        public int FaultId { get; set; }
        public int ReportId { get; set; }
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

        public IList<RouteCall> Completed_Route_Call { get; set; }

        public List<int> Completed_Route_CallId { get; set; }


        public IList<VReportSummary> V_Report_Summary_All { get; set; }

        public IList<VCreateReports> V_Create_Reports_All { get; set; }

        public IList<Fault> Fault_All { get; set; }

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
            GetUserName();

            V_Create_Reports_All = await _context.VCreateReports
                .AsNoTracking()
                .ToListAsync();


            // This is to get what routes need to be displayed on the page
            Completed_Route_CallId = V_Create_Reports_All
                .Select(m => m.PkCallId)
                .Distinct()
                .ToList();

            /* Get Completed Route_Call */
            Completed_Route_Call = await _context.RouteCall
                .Include(c => c.Route)
                    .ThenInclude(c => c.Machine_Train_List)
                .Where(c => Completed_Route_CallId.Contains(c.PkCallId))
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
            GetUserName();

            V_Report_Summary_All = await _context.VReportSummary
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
                    // Is there an open fault?
                    if (inputreport.Status == "Open")
                    {
                        // Was the latest condition a 2 (No Action)
                        if (inputreport.Condition == "No Action")
                        {
                            /*
                                Create a new report on the same fault.
                                -- Set condition_mag = 2, routine and released
                             */

                            var new_report = new Report()
                            {
                                FkFaultId = inputreport.FaultId,
                                ReportDate = DateTime.Now,
                                MeasurementDate = DateTime.Now,
                                FkConditionId = 1, // No Action Mag = 2
                                FkReportTypeId = 1, // Routine
                                FkReportStageId = 4, //released
                                AnalystName = Current_User,
                                ReportIsActive = true,
                                OriginCallId = inputreport.PK_CallId
                            };

                            _context.Report.Add(new_report);
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

                        }
                        else // Was the latest condition a 2 (No Action)
                        {
                            /*
                                Close the existing fault
                                -- Stamp the close date field in the fault table
                                -- Input the comment to the fault table    
                            */

                            var Edit_Fault = await _context.Fault.FirstOrDefaultAsync(n => n.PkFaultId == inputreport.FaultId);

                            if (Edit_Fault == null)
                            {
                                return NotFound();
                            }

                            Edit_Fault.CloseDate = DateTime.Now;
                            Edit_Fault.ClosureComment = inputreport.Comments;

                            _context.Attach(Edit_Fault).State = EntityState.Modified;

                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!FaultExists(Edit_Fault.PkFaultId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }



                            /*
                                Create a new fault on this machine
                                -- set the fault type to no fault
                                -- Create a new report on the new fault.
                                -- Set condition_mag = 2, routine and released
                            */

                            var new_fault = new Fault()
                            {
                                FkMachineTrainId = inputreport.MachineTrainId,
                                FkPrimaryComponentTypeId = 1,
                                FkTechnologyId = 1,
                                FkFaultTypeId = 1,
                                CreateDate = DateTime.Now,
                                FaultIsActive = true
                            };

                            _context.Fault.Add(new_fault);
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

                            var new_report = new Report()
                            {
                                FkFaultId = new_fault.PkFaultId,
                                ReportDate = DateTime.Now,
                                MeasurementDate = DateTime.Now,
                                FkConditionId = 1,
                                FkReportTypeId = 1,
                                FkReportStageId = 4,
                                AnalystName = Current_User,
                                ReportIsActive = true,
                                OriginCallId = inputreport.PK_CallId
                            };


                            _context.Report.Add(new_report);

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
                        }

                    }
                    else  // Is there an open fault?
                    {
                        /*
                                Create a new fault on this machine
                                -- set the fault type to no fault
                                -- Create a new report on the new fault.
                                -- Set condition_mag = 2, routine and released
                            */

                        var new_fault = new Fault()
                        {
                            FkMachineTrainId = inputreport.MachineTrainId,
                            FkPrimaryComponentTypeId = 1,
                            FkTechnologyId = 1,
                            FkFaultTypeId = 1,
                            CreateDate = DateTime.Now,
                            FaultIsActive = true
                        };

                        _context.Fault.Add(new_fault);
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

                        var new_report = new Report()
                        {
                            FkFaultId = new_fault.PkFaultId,
                            ReportDate = DateTime.Now,
                            MeasurementDate = DateTime.Now,
                            FkConditionId = 1,
                            FkReportTypeId = 1,
                            FkReportStageId = 4,
                            AnalystName = Current_User,
                            ReportIsActive = true,
                            OriginCallId = inputreport.PK_CallId
                        };


                        _context.Report.Add(new_report);

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

                    }
                }
                else if (inputreport.MainOption == "anomaly") // Anomaly
                {
                    // Is there an open fault?
                    if (inputreport.Status == "Open")
                    {
                        // Was the latest condition a 2 (No Action)
                        if (inputreport.Condition == "No Action")
                        {
                            /*
                                Close the existing fault
                                -- Stamp the close date field in the fault table  
                            */
                            var Edit_Fault = await _context.Fault.FirstOrDefaultAsync(n => n.PkFaultId == inputreport.FaultId);

                            if (Edit_Fault == null)
                            {
                                return NotFound();
                            }

                            Edit_Fault.CloseDate = DateTime.Now;

                            _context.Attach(Edit_Fault).State = EntityState.Modified;

                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!FaultExists(Edit_Fault.PkFaultId))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            Console.WriteLine("Close the existing fault");


                            /*
                                Create a new fault on this machine
                                -- Create a new report on the new fault.
                                -- Set condition_mag = 3, routine and In progress
                            */

                            var new_fault = new Fault()
                            {
                                FkMachineTrainId = inputreport.MachineTrainId,
                                FkPrimaryComponentTypeId = 1,
                                FkTechnologyId = 1,
                                CreateDate = DateTime.Now,
                                FaultIsActive = true
                            };

                            _context.Fault.Add(new_fault);
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

                            var new_report = new Report()
                            {
                                FkFaultId = new_fault.PkFaultId,
                                ReportDate = DateTime.Now,
                                MeasurementDate = DateTime.Now,
                                FkConditionId = 2,
                                FkReportTypeId = 1,
                                FkReportStageId = 1,
                                AnalystName = Current_User,
                                ReportIsActive = true,
                                OriginCallId = inputreport.PK_CallId
                            };


                            _context.Report.Add(new_report);

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

                            Console.WriteLine("Set condition_mag = 3, routine and In progress");

                        }
                        else
                        {
                            /*
                                Create a new report on the same fault.
                                -- Set condition_mag = 2, routine and released
                             */

                            var new_report = new Report()
                            {
                                FkFaultId = inputreport.FaultId,
                                ReportDate = DateTime.Now,
                                MeasurementDate = DateTime.Now,
                                FkConditionId = 1,
                                FkReportTypeId = 1,
                                FkReportStageId = 4,
                                AnalystName = Current_User,
                                ReportIsActive = true,
                                OriginCallId = inputreport.PK_CallId
                            };


                            _context.Report.Add(new_report);

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

                            Console.WriteLine("Create a new report on the same fault. -- Set condition_mag = 2, routine and released");

                        }

                    }
                    else
                    {
                        /*
                                Create a new fault on this machine
                                -- Create a new report on the new fault.
                                -- Set condition_mag = 3, routine and In progress
                            */

                        var new_fault = new Fault()
                        {
                            FkMachineTrainId = inputreport.MachineTrainId,
                            FkPrimaryComponentTypeId = 1,
                            FkTechnologyId = 1,
                            CreateDate = DateTime.Now,
                            FaultIsActive = true
                        };

                        _context.Fault.Add(new_fault);
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

                        var new_report = new Report()
                        {
                            FkFaultId = new_fault.PkFaultId,
                            ReportDate = DateTime.Now,
                            MeasurementDate = DateTime.Now,
                            FkConditionId = 2,
                            FkReportTypeId = 1,
                            FkReportStageId = 1,
                            AnalystName = Current_User,
                            ReportIsActive = true,
                            OriginCallId = inputreport.PK_CallId
                        };


                        _context.Report.Add(new_report);

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
                        Console.WriteLine("Create a new fault on this machine -- Create a new report on the new fault. -- Set condition_mag = 3, routine and In progress");
                    }
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
            return _context.Fault.Any(e => e.PkFaultId == id);
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.PkReportId == id);
        }
    }
}