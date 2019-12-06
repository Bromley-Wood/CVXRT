using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReportingTool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reportingtool.Pages
{
    public class ReviewReportsModel : PageModel
    {
        private readonly ReportingTool.Models.DatabaseContext _context;

        public ReviewReportsModel(ReportingTool.Models.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Action> Action { get; set; }
        public async Task OnGetAsync()
        {
            Action = await _context.Action.ToListAsync();
        }

        
        
    }
}