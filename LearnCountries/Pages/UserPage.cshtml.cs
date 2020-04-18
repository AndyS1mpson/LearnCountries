using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class UserPageModel : PageModel
    {
        [BindProperty(Name="id",SupportsGet=true)]
        public int id{get;set;}
        public User user{get;set;}
        private IUserRepository _userRepository;
        public string img{get;set;}
        public UserPageModel(IUserRepository userRepository)
            => _userRepository = userRepository;
        public void OnGet()
        {
            user = _userRepository.GetUserById(id);
            //img = new FileContentResult(user.Avatar,"image/png");
            img = string.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(user.Avatar));

        }
        public void OnPost()
        {
        }

    }
}
