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
    public class CapitalsTasksModel : PageModel
    {
        [BindProperty(Name="id",SupportsGet=true)]
        public int id{get;set;}
        [BindProperty(Name="letters",SupportsGet=true)]
        public string letters{get;set;}
        [BindProperty(Name="num",SupportsGet=true)]
        public int num{get;set;}
        public User user{get;set;}
        [BindProperty(Name="curNum",SupportsGet=true)]
        public int numOfCurTask{get;set;}
        private IUserRepository _userRepository;
        private ICountryRepository _countryRepository;
        public CapitalsTasksModel(IUserRepository userRepository,ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
        }
        public void OnGet()
        {
            user = _userRepository.GetUserById(id);
            char[] let = letters.ToArray();
            
        }
    }
}
