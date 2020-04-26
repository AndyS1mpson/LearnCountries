using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using LearnCountries.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class UserPageModel : PageModel
    {
        [BindProperty(Name="id",SupportsGet=true)]
        public int id{get;set;}
        public User user{get;set;}
        private IUserRepository _userRepository;
        private ICountryRepository _countryRepository;
        public string img{get;set;}
        [BindProperty(Name="file",SupportsGet=true)]
        public IFormFile file{get;set;}
        [BindProperty(Name="CheckedLetter",SupportsGet=true)]
        public List<char> checkedLetters{get;set;}
        public List<Country> allCountries{get;set;}
        public int[] numCountries{get;set;}
        public string learn{get;set;}
        public string number{get;set;}
        public UserPageModel(IUserRepository userRepository,ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
        }
        public void OnGet()
        {
            numCountries = new int[24];
            string let = "ABCDEFGHIJKLMNOPQRSTUVYZ";
            allCountries = _countryRepository.GetCountries().ToList();
            for(int i = 0;i < 24;i++)
            {
                numCountries[i] = _countryRepository.GetCountryByMainLet(let[i]).ToArray().Length;
            }
            user = _userRepository.GetUserById(id);
            //img = new FileContentResult(user.Avatar,"image/png");
            img = string.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(user.Img));

        }
        public IActionResult OnPost()
        {

            if(file != null)
            {
                user = _userRepository.GetUserById(id);
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
                _userRepository.UpdateUser(new User(){
                    Name = user.Name,
                    SurName = user.SurName,
                    Email = user.Email,
                    Password = user.Password,
                    UserName = user.UserName,
                    Score = user.Score,
                    UserAccess = user.UserAccess,
                    TaskSettings = user.TaskSettings,
                    Img = fileBytes
                });

                return RedirectToPage("UserPage",new {id = user.Id});
            }
            else{
                learn = Request.Form["radio"];
                number = Request.Form["numberOfTasks"];

                if(learn == "Capitals")
                    return RedirectToPage("CapitalsTasks",new { id = id, letters = new string(checkedLetters.ToArray()), num= number,curNum = 1});
                else
                    return RedirectToPage("FlagsTasks",new { id = id, letters = new string(checkedLetters.ToArray()), num= number,curNum = 1});
                    
            }
        }
        public void OnPost1()
        {

        }
    }
}
