
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Reportingtool.Pages
{
    public class BasePageModel : PageModel
    {
        public string Current_User { get; set; }

        public void GetUserName()
        {
            Current_User = User.Identity.Name;
            if (Current_User == null){
                Current_User = "admin";
            }
           
            
           
        }
    }
}