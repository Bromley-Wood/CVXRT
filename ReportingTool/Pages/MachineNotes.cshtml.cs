using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using ReportingTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{


    public class MachineNotesModel : BasePageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public MachineNotesModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Machine_Train_Notes> Machine_Train_Notes_All { get; set; }

        public IList<Machine_Train_Files> Machine_Train_Files { get; set; }

        public Machine_Train Current_Machine_Train { get; set; }

        

        public List<Machine_Train_Files> Machine_Train_File_All { get; set; }

        [BindProperty]
        public Machine_Train_Notes New_Machine_Note { get; set; }

        [BindProperty]
        public int Machine_Train_Id { get; set; }

        [BindProperty]
        public int Machine_Train_Note_Id { get; set; }

        [BindProperty]
        public string Machine_Train_Note_Content { get; set; }

        [BindProperty]
        public bool Machine_Train_Note_ShowOnReport { get; set; }



        public async Task OnGetAsync(int? id)
        {
            if (id == null)
            {
                id = 1;
                Console.WriteLine("No ID Specified. Default machine is displayed.");
            }

            Console.WriteLine($"Displaying machine {id}");

            Current_Machine_Train = await _context.Machine_Train.FirstOrDefaultAsync(m => m.MachineTrainId == id);


            Machine_Train_Notes_All = await _context.Machine_Train_Notes
                //.Include(m => m.Machine_Train)
                .Where(n => n.MachineTrainId == id)
                .Where(n => n.MachineTrainNote_IsActive == true)
                .OrderByDescending(n => n.Note_Date)
                .AsNoTracking()
                .ToListAsync();

            Machine_Train_File_All = await _context.Machine_Train_Files
                .Where(f => f.FK_MachineTrainId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateNewMachinenote()
        {


            New_Machine_Note.MachineTrainNote_IsActive = true;
            New_Machine_Note.Note_Date = DateTime.Now;
            New_Machine_Note.MachineTrainNote_IsActive = true;
            New_Machine_Note.Analyst_Name = Current_User;

            _context.Machine_Train_Notes.Add(New_Machine_Note);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineNoteExists(New_Machine_Note.MachineTrainId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machinenotes", new { id = New_Machine_Note.MachineTrainId });
        }

        public async Task<IActionResult> OnPostArchiveMachineNote()
        {

            var Edit_Machine_Note = await _context.Machine_Train_Notes.FirstOrDefaultAsync(n => n.PK_MachineTrainNoteId == Machine_Train_Note_Id);

            if (Edit_Machine_Note == null)
            {
                return NotFound();
            }

            Edit_Machine_Note.MachineTrainNote_IsActive = false;

            _context.Attach(Edit_Machine_Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineNoteExists(Edit_Machine_Note.PK_MachineTrainNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machinenotes", new { id = Edit_Machine_Note.MachineTrainId });
        }

        public async Task<IActionResult> OnPostEditMachineNote()
        {
            var Edit_Machine_Note = await _context.Machine_Train_Notes.FirstOrDefaultAsync(n => n.PK_MachineTrainNoteId == Machine_Train_Note_Id);

            if (Edit_Machine_Note == null)
            {
                return NotFound();
            }

            Console.WriteLine("**************");
            Console.WriteLine(Machine_Train_Note_ShowOnReport);
            Console.WriteLine("**************");

            Edit_Machine_Note.MachineTrain_Note = Machine_Train_Note_Content;
            Edit_Machine_Note.MachineTrainNote_ShowOnReport = Machine_Train_Note_ShowOnReport;
            Edit_Machine_Note.Note_Date = DateTime.Now;

            _context.Attach(Edit_Machine_Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineNoteExists(Edit_Machine_Note.PK_MachineTrainNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machinenotes", new { id = Edit_Machine_Note.MachineTrainId });
        }

        
        public IActionResult OnPostUploadAttachments()
        {
            var data = Request.Form;

            foreach (var file in data.Files)
            {
                Machine_Train_Files New_Machine_Train_File = new Machine_Train_Files();
                
                Console.WriteLine(file.FileName);
                New_Machine_Train_File.FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                New_Machine_Train_File.FK_MachineTrainId = Machine_Train_Id;
                New_Machine_Train_File.Upload_Date = DateTime.Now;
                New_Machine_Train_File.Uploaded_By = Current_User;

                _context.Machine_Train_Files.Add(New_Machine_Train_File);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineFileExists(New_Machine_Train_File.PK_FilePathId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                string save_path = $"wwwroot\\MachineAttach\\{New_Machine_Train_File.FileName}";
                //string save_path = $"c:\\MachineAttach\\{New_Machine_Train_File.FileName}";
                using (var fileStream = new FileStream(save_path, FileMode.Create))
                {
                    
                    file.CopyTo(fileStream);
                }
                
            }
            return new RedirectToPageResult("/Machinenotes", new { id = Machine_Train_Id });
        }
        private bool MachineFileExists(int id)
        {
            return _context.Machine_Train_Files.Any(f => f.PK_FilePathId == id);
        }

        private bool MachineNoteExists(int id)
        {
            return _context.Machine_Train_Notes.Any(n => n.MachineTrainId == id);
        }

        public IActionResult GetMachineList()
        {
            var Machine_Train_All = _context.Machine_Train
                .Select(m => m.Machine_Train_Name)
                .AsNoTracking()
                .ToList();

            //Machine_Train_All.ForEach(Console.WriteLine);

            return new JsonResult(Machine_Train_All);
        }

        public async Task<IActionResult> OnPostGoToMachineTrain()
        {
            if (_context.Machine_Train.Any(m => m.MachineTrainId == Machine_Train_Id))
            {
                return RedirectToPage("/Machinenotes", new { id = Machine_Train_Id });
            }
            else {
                return RedirectToPage("/Machinenotes", new { id = 1 });
            }
        }


    }


}