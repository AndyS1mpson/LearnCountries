using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class UpdateCountryModel : PageModel
    {
        [BindProperty(Name="id",SupportsGet=true)]
        public int id{get;set;}
        [BindProperty(Name="countryName",SupportsGet=true)]
        public string countryName{get;set;}
        [BindProperty(Name="file",SupportsGet=true)]
        public IFormFile file{get;set;}
        public Country updateCountry{get;set;}
        IWebHostEnvironment _appEnvironment;
        private ICountryRepository _countryRepository;
        public UpdateCountryModel(ICountryRepository countryRepository,IWebHostEnvironment appEnvironment)
        {
             _countryRepository = countryRepository;
             _appEnvironment = appEnvironment;
        }
        public void OnGet()
        {
            updateCountry = _countryRepository.GetCountry(countryName);
        }
        public IActionResult OnPost()
        {
            updateCountry = _countryRepository.GetCountry(countryName);

            var country = Request.Form["country"];
            var capital = Request.Form["capital"];
            string path = "/images/Flags/" + file.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            _countryRepository.UpdateCountry(new Country{
                CountryName = country,
                CapitalName = capital,
                Flag = file.FileName,
                MainLetter = country.ToString()[0]
            });
            
            return RedirectToPage("AdminPage",new {id = id});
        }
    }
}
