using System.Collections.Generic;
using LearnCountries.Models;

namespace LearnCountries.Interfaces
{
    public interface ICountryRepository
    {
         public IEnumerable<Country> GetCountries();
         public Country GetCountry(string name);
         public void UpdateCountry(Country country);
         public void CreateCountry(Country country);
         public void DeleteCountry(string name);
    }
}