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
        public Country enterCountry{get;set;}
        public int numEC{get;set;}
        public int userPosition{get;set;}
        public List<User> topUsers{get;set;}
        private IUserRepository _userRepository;
        public Country[] countryArray{get;set;}
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
            topUsers = new List<User>();
            // генерация топ 3 юзеров и позиции юзера
            var users = _userRepository.GetUsers().OrderByDescending(x=>x.Score).ToList();
                for(int i= 0;i<3;i++)
                    topUsers.Add(users[i]);
                for(int i = 0;i < users.Count;i++)
                    if(users[i] == user)
                    { 
                    userPosition = i+1;
                    break;
                    }

            // генерация стран
            Random rand = new Random();
            var randLet = rand.Next(0,let.Length-1);        // выбираем букву на которую будет начинается страна
            var countries = _countryRepository.GetCountryByMainLet(let[randLet]).ToList();
            enterCountry = countries[rand.Next(0,countries.Count()-1)];
            countryArray = new Country[4];
            // выбираем еще 3 рандомные страны и записываем все в массив для вывода на экран вариантов ответа
            numEC = rand.Next(0,3);
            countryArray[numEC] = enterCountry;
            for(int i = 0;i < 4;i++)
            {    
                if(i != numEC)
                {    
                    countryArray[i] = _countryRepository.GetRandomCountry();
                    for(int j = 0;j < i;j++)
                    if(countryArray[j] == countryArray[i] && countryArray[j] != countryArray[numEC])
                    {
                        countryArray[i] = _countryRepository.GetRandomCountry();
                        i--;
                    }
                }
            }
        }
    }
}
