using System;
using System.Collections.Generic;
using System.Linq;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnCountries.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db)
            => _db = db;
        public void CreateCountry(Country country)
            {
                _db.Add(country);
                _db.SaveChanges();
            }
        public void DeleteCountry(string name)
        {
            Country countryToDelete=_db.Countries.FirstOrDefault(x=>x.CountryName==name);
            if(countryToDelete==null)
                throw new NullReferenceException("Country is not exist");
            _db.Countries.Remove(countryToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<string> GetCapitals()
            =>_db.Countries.Select(x=>x.CapitalName).Distinct();
            //_db.Countries.FromSqlRaw("SELECT DISTINCT CapitalName ").AsEnumerable();
        
        public IEnumerable<Country> GetCountryByMainLet(char let)
            => _db.Countries.Where(x=>x.MainLetter == let).ToList();

        public IEnumerable<Country> GetCountries()
            =>_db.Countries.Where(x=>true).ToList();

        public Country GetCountry(string name)
            =>_db.Countries.FirstOrDefault(x=>x.CountryName == name);

        public void UpdateCountry(Country country)
        {
            var countryForUpdate=_db.Countries.FirstOrDefault(x=>x.CountryName==country.CountryName);
            if(countryForUpdate==null)
                throw new NullReferenceException("Country isn't exist");
            countryForUpdate.CountryName=country.CountryName;
            countryForUpdate.CapitalName=country.CapitalName;
            countryForUpdate.Flag=country.Flag;

            _db.SaveChanges();
        }
        public Country GetRandomCountry()
        {
            var countries = GetCountries().ToList();
            Random rand = new Random();
            return countries[rand.Next(0,countries.Count - 1)];
        }
    }
}