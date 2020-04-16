using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class LogInModel : PageModel
    {
        [Required]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        public IUserRepository _userRepository;
        public LogInModel(IUserRepository userRepository)
            => _userRepository = userRepository;

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
           Email = Request.Form["email"];
           Password = Request.Form["pass"];
           
        }
        
       
    }
}
