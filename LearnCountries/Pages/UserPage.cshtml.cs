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
        [BindProperty(Name="user",SupportsGet=true)]
        public string email{get;set;}
        public User user{get;set;}
        private IUserRepository _userRepository;
        public UserPageModel(IUserRepository userRepository)
            => _userRepository = userRepository;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            email = Request.Query["id"];
            user = _userRepository.GetUserByEmail(email);
        }

    }
}
