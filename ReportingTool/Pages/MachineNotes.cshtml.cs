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

        [BindProperty]
        public IList<Machine_Train_Notes> Machine_Train_Notes_All { get; set; }

        public Machine_Train Machine_Train { get; set;}

        public async Task OnGetAsync(int? id)
        {
            if (id == null)
            {
                id = 1;
                Console.WriteLine("No ID Specified. Default machine is displayed.");
            }

            Machine_Train = await _context.Machine_Train.FirstOrDefaultAsync(m => m.MachineTrainId == id);

            //Machine_Train_Notes_All = await _context.Machine_Train_Notes
            //    //.Include(m => m.Machine_Train)
            //    .Where(m => m.MachineTrainId == id)
            //    .AsNoTracking()
            //    .ToListAsync();
        }

    }
}