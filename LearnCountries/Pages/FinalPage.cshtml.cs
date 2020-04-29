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
    public class FinalPageModel : PageModel
    {
        [BindProperty(Name="id",SupportsGet=true)]
        public int id{get;set;}
        public User user{get;set;}
        public List<User> topUsers{get;set;}
        public int userPosition{get;set;}
        private IUserRepository _userRepository;
        private ICountryRepository _countryRepository;
        public FinalPageModel(IUserRepository userRepository,ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
        }
        public void OnGet()
        {
            user = _userRepository.GetUserById(id);
            topUsers = new List<User>();
            // генерация топ 3 юзеров и позиции юзера
            var users = _userRepository.GetUsers().OrderByDescending(x=>x.Score).ToList();
                for(int i= 0;i<3;i++)
                    topUsers.Add(users[i]);
                for(int i = 0;i < users.Count;i++)
                    if(users[i] == user)
                    { 
                    userPosition = i+1;
                    break;
                    }
        }
        public IActionResult OnPost()
        {
            user = _userRepository.GetUserById(id);
            if(user.UserAccess == 0)
            return RedirectToPage("UserPage",new { id = id});
            else 
            return RedirectToPage("AdminPage",new { id = id});

        }
    }
}
