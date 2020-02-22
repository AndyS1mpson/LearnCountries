using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnCountries.Controllers.Test
{
    [ApiController]
    [Route("api/country/test")]
    public class TestCountryCrudController
    {
        private ICountryRepository _countryRepository;
        public TestCountryCrudController(ICountryRepository countryRepository)
                =>_countryRepository=countryRepository;
        [HttpPost]
        public void PostCountry([FromBody]Country country)
                =>_countryRepository.CreateCountry(country);
    }
}