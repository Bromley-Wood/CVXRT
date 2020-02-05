using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Reportingtool.Models.Db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{


    public class MachineNotesModel : BasePageModel
    {
        private readonly DEV_ClientProjectContext _context;

        public MachineNotesModel(DEV_ClientProjectContext context)
        {
            _context = context;
        }

        public IList<MachineTrainNotes> Machine_Train_Notes_All { get; set; }

        public IList<MachineTrainFiles> Machine_Train_Files { get; set; }

        public MachineTrain Current_Machine_Train { get; set; }

        

        public List<MachineTrainFiles> Machine_Train_File_All { get; set; }

        [BindProperty]
        public MachineTrainNotes New_Machine_Note { get; set; }

        [BindProperty]
        public int Machine_Train_Id { get; set; }

        [BindProperty]
        public int Machine_Train_Note_Id { get; set; }

        [BindProperty]
        public string Machine_Train_Note_Content { get; set; }

        [BindProperty]
        public bool Machine_Train_Note_ShowOnReport { get; set; }


        [BindProperty]
        public int MachineFileID_ToDelete { get; set; }


        public async Task OnGetAsync(int? id)
        {
            GetUserName();

            if (id == null)
            {
                id = 1;
                Console.WriteLine("No ID Specified. Default machine is displayed.");
            }

            Console.WriteLine($"Displaying machine {id}");

            Current_Machine_Train = await _context.MachineTrain.FirstOrDefaultAsync(m => m.PkMachineTrainId == id);

            Console.WriteLine("---------------");
            Console.WriteLine(Current_Machine_Train.MachineTrainLongName);
            Console.WriteLine("---------------");

            Machine_Train_Notes_All = await _context.MachineTrainNotes
                //.Include(m => m.Machine_Train)
                .Where(n => n.FkMachineTrainId == id)
                .Where(n => n.MachineTrainNoteIsActive == true)
                .OrderByDescending(n => n.NoteDate)
                .AsNoTracking()
                .ToListAsync();

            Console.WriteLine("---------------");
            Console.WriteLine(Machine_Train_Notes_All.Count);
            Console.WriteLine("---------------");

            Machine_Train_File_All = await _context.MachineTrainFiles
                .Where(f => f.FkMachineTrainId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateNewMachinenote()
        {
            GetUserName();

            New_Machine_Note.MachineTrainNoteIsActive = true;
            New_Machine_Note.NoteDate = DateTime.Now;
            New_Machine_Note.MachineTrainNoteIsActive = true;
            New_Machine_Note.AnalystName = Current_User;

            _context.MachineTrainNotes.Add(New_Machine_Note);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineNoteExists(New_Machine_Note.FkMachineTrainId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machinenotes", new { id = New_Machine_Note.FkMachineTrainId });
        }

        public async Task<IActionResult> OnPostArchiveMachineNote()
        {

            var Edit_Machine_Note = await _context.MachineTrainNotes.FirstOrDefaultAsync(n => n.PkMachineTrainNoteId == Machine_Train_Note_Id);

            if (Edit_Machine_Note == null)
            {
                return NotFound();
            }

            Edit_Machine_Note.MachineTrainNoteIsActive = false;

            _context.Attach(Edit_Machine_Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineNoteExists(Edit_Machine_Note.PkMachineTrainNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machinenotes", new { id = Edit_Machine_Note.FkMachineTrainId });
        }

        public async Task<IActionResult> OnPostEditMachineNote()
        {
            var Edit_Machine_Note = await _context.MachineTrainNotes.FirstOrDefaultAsync(n => n.PkMachineTrainNoteId == Machine_Train_Note_Id);

            if (Edit_Machine_Note == null)
            {
                return NotFound();
            }

            Console.WriteLine("**************");
            Console.WriteLine(Machine_Train_Note_ShowOnReport);
            Console.WriteLine("**************");

            Edit_Machine_Note.MachineTrainNote = Machine_Train_Note_Content;
            Edit_Machine_Note.MachineTrainNoteShowOnReport = Machine_Train_Note_ShowOnReport;
            Edit_Machine_Note.NoteDate = DateTime.Now;

            _context.Attach(Edit_Machine_Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineNoteExists(Edit_Machine_Note.PkMachineTrainNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machinenotes", new { id = Edit_Machine_Note.FkMachineTrainId });
        }

        
        public IActionResult OnPostUploadAttachments()
        {
            GetUserName();

            var data = Request.Form;

            foreach (var file in data.Files)
            {
                MachineTrainFiles New_Machine_Train_File = new MachineTrainFiles();
                
                Console.WriteLine(file.FileName);
                New_Machine_Train_File.FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                New_Machine_Train_File.FkMachineTrainId = Machine_Train_Id;
                New_Machine_Train_File.UploadDate = DateTime.Now;
                New_Machine_Train_File.UploadedBy = Current_User;

                _context.MachineTrainFiles.Add(New_Machine_Train_File);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineFileExists(New_Machine_Train_File.PkFilePathId))
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
            return _context.MachineTrainFiles.Any(f => f.PkFilePathId == id);
        }

        private bool MachineNoteExists(int id)
        {
            return _context.MachineTrainNotes.Any(n => n.FkMachineTrainId == id);
        }

        public IActionResult GetMachineList()
        {
            var Machine_Train_All = _context.MachineTrain
                .Select(m => m.MachineTrain1)
                .AsNoTracking()
                .ToList();

            //Machine_Train_All.ForEach(Console.WriteLine);

            return new JsonResult(Machine_Train_All);
        }

        public async Task<IActionResult> OnPostGoToMachineTrain()
        {
            if (_context.MachineTrain.Any(m => m.PkMachineTrainId == Machine_Train_Id))
            {
                return RedirectToPage("/Machinenotes", new { id = Machine_Train_Id });
            }
            else {
                return RedirectToPage("/Machinenotes", new { id = 1 });
            }
        }

        public async Task<IActionResult> OnPostDeleteMachinefile()

        {

            var MachineFile_ToDelete = await _context.MachineTrainFiles.FirstOrDefaultAsync(f => f.PkFilePathId == MachineFileID_ToDelete);

            if (MachineFile_ToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _context.MachineTrainFiles.Remove(MachineFile_ToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Machinenotes", new { id = Machine_Train_Id });
            }
            catch (DbUpdateException /* ex */)
            {
                throw;
            }
        }

    }


}