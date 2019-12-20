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

    }
}