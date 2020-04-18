using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using LearnCountries;

namespace MyApp.Namespace
{

    public class RegisterModel : PageModel
    {
        [Required]
        public string name{get; set;}
        [Required]
        public string surName{get;set;}
        [Required]
        public string userName{get;set;}
        [Required]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
        
        public IUserRepository _userRepository;
        public RegisterModel(IUserRepository userRepository)
            => _userRepository = userRepository;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            name = Request.Form["Name"];
            surName = Request.Form["SurName"];
            userName = Request.Form["UserName"];
            email = Request.Form["Email"];
            password = Request.Form["Password"];

            if(ModelState.IsValid)
            {
                User user =  _userRepository.GetUserByEmail(email);
                if(user == null)
                {
                    //Image img = Image.FromFile("C:\Users\Пользователь\Documents\GitHub\LearnCountries\LearnCountries\wwwroot\images");
                   string path = "C:\\Users\\Пользователь\\Documents\\GitHub\\LearnCountries\\LearnCountries\\wwwroot\\images\\unnamed.jpg";
                    _userRepository.CreateUser(new User{
                        Name = name,
                        SurName = surName,
                        UserName = userName,
                        UserAccess = 0,
                        Email = email,
                        Password = password,
                        Score = 0,
                        Img = ConvertImage.ImageToByteArrayFromFilePath(path)
                    });
                    return Redirect("/Login");
                }
            }
                return Redirect("/notFound");
        }

    }
}
