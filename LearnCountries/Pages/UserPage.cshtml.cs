using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class UserPageModel : PageModel
    {
        [BindProperty(Name="user",SupportsGet=true)]
        public string id{get;set;}
        public void OnGet()
        {
        }
        public void OnPost()
        {
            id = Request.Query["id"];

        }

    }
}
