
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
            
            string[] res = Current_User.Split("\\");
            if (res.Length == 2)
            {
                Current_User = res[1];
                Console.WriteLine("Current User Name is {0}", Current_User);
            }
            else
            {
                Current_User = "admin";
                Console.WriteLine("Couldn't Get User Name. The name 'admin' is used instead");
            }
        }
    }
}