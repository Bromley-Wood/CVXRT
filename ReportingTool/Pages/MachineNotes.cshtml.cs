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


    public class MachineNotesModel : BasePageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public MachineNotesModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        //[BindProperty]
        public IList<Machine_Train_Notes> Machine_Train_Notes_All { get; set; }

        public Machine_Train Current_Machine_Train { get; set; }

        [BindProperty]
        public Machine_Train_Notes New_Machine_Note { get; set; }

        [BindProperty]
        public int Machine_Train_Note_Id { get; set; }


        public async Task OnGetAsync(int? id)
        {
            if (id == null)
            {
                id = 1;
                Console.WriteLine("No ID Specified. Default machine is displayed.");
            }

            Current_Machine_Train = await _context.Machine_Train.FirstOrDefaultAsync(m => m.MachineTrainId == id);

            Machine_Train_Notes_All = await _context.Machine_Train_Notes
                //.Include(m => m.Machine_Train)
                .Where(n => n.MachineTrainId == id)
                .Where(n => n.MachineTrainNote_IsActive == true)
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

            return RedirectToPage("/Machinenotes", New_Machine_Note.MachineTrainId);
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

            return RedirectToPage("/Machinenotes", Edit_Machine_Note.MachineTrainId);
        }


        private bool MachineNoteExists(int id)
        {
            return _context.Machine_Train_Notes.Any(n => n.MachineTrainId == id);
        }

    }


}