
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReportingTool.Models;
using System;
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

        public string Current_User { get; set; }
        public async Task OnGetAsync()
        {
            Current_User = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            string[] res = Current_User.Split("\\");
            if (res.Length == 2)
            {
                Current_User = res[1];
                Console.WriteLine("Current User Name is {0}", Current_User);
            }
            {
                Current_User = "UnknownUser";
                Console.WriteLine("Couldn't Get User Name. The name 'UnknownUser' is used instead");
            }
        }
    }
}