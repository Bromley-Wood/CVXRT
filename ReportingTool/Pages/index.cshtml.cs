using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReportingTool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public IndexModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }
    }
}