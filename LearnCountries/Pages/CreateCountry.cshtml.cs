using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class CreateCountryModel : PageModel
    {
        private ICountryRepository _countryRepository;
        IWebHostEnvironment _appEnvironment;
        [BindProperty(Name="file",SupportsGet=true)]
        public IFormFile file{get;set;}
        public CreateCountryModel(ICountryRepository countryRepository, IWebHostEnvironment appEnvironment)
        { 
            _countryRepository = countryRepository;
            _appEnvironment = appEnvironment;
        }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            var countryName =Request.Form["countryName"];
            var capitalName =Request.Form["capitalName"];
            string path = "/images/Flags/" + file.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            _countryRepository.CreateCountry(new Country{
                CountryName = countryName,
                CapitalName = capitalName,
                Flag = file.FileName,
                MainLetter = countryName.ToString()[0]
            });

        }
    }
}
