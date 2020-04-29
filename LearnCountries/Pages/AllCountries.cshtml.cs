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
    public class AllCountriesModel : PageModel
    {
        [BindProperty(Name="id",SupportsGet=true)]
        public int id{get;set;}
        private ICountryRepository _countryRepository;
        public List<Country> allCountries{ get; set;}
        public int balance{get;set;}
        public int unit {get;set;}
        public AllCountriesModel(ICountryRepository countryRepository)
            => _countryRepository = countryRepository;
        public void OnGet()
        {
            allCountries = _countryRepository.GetCountries().ToList();
            balance = allCountries.Count % 13;
            unit = allCountries.Count / 13;
        }
        public IActionResult OnPost()
        {
            var country = Request.Form["country"];

            return RedirectToPage("UpdateCountry",new {id = id, countryName = country });
        }
    }
}
