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
    public class CreateCountryModel : PageModel
    {
        private ICountryRepository _countryRepository;
        public CreateCountryModel(ICountryRepository countryRepository)
            => _countryRepository = countryRepository;
        public void OnGet()
        {

        }
        public void OnPost()
        {
            var countryName =Request.Form["countryName"];
            var capitalName =Request.Form["capitalName"];
            var path =Request.Form["path"];

            _countryRepository.CreateCountry(new Country{
                CountryName = countryName,
                CapitalName = capitalName,
                Flag = path,
                MainLetter = countryName.ToString()[0]
            });

        }
    }
}
