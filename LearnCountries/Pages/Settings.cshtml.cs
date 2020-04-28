using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class SettingsModel : PageModel
    {
        private ICountryRepository _countryRepository;

        public SettingsModel(ICountryRepository countryRepository)
            => _countryRepository = countryRepository;
        public void OnGet()
        {

        }
        public void OnPost()
        {
            var minV = Int32.Parse(Request.Form["minV"]);
            var maxV = Int32.Parse(Request.Form["maxV"]);
            NumberOfTasks.minValue = minV;
            NumberOfTasks.maxValue = maxV;
        }
    }
}
