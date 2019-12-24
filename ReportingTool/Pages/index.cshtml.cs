
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
    public class IndexModel : BasePageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public IndexModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        
        public IActionResult OnGetSearch(string term)
        {
            var machines = new object();

            var names = _context.Machine_Train
                .Where(m => m.Machine_Train_Name.Contains(term))
                .Select(m => new { label = m.Machine_Train_Name, value = m.MachineTrainId })
                .ToList();
            return new JsonResult(names);
        }



    }
}