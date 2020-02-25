using System.Collections.Generic;
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
        
        [HttpGet("{countryName}")]
        public Country GetCountry(string countryName)
            =>_countryRepository.GetCountry(countryName);

        [HttpGet]
        public IEnumerable<Country> GetCountries()
            =>_countryRepository.GetCountries(); 
        
        [HttpGet("capitals")]
        public IEnumerable<string> GetCapitals()
            =>_countryRepository.GetCapitals();
        [HttpPost]
        public void PostCountry([FromBody]Country country)
            =>_countryRepository.CreateCountry(country);
        
        [HttpPut]
        public void PutCountry([FromBody]Country country)
            =>_countryRepository.UpdateCountry(country);

        [HttpDelete("{countryname}")]
        public void DeleteCountry(string countryName)
            =>_countryRepository.DeleteCountry(countryName);
    }
}