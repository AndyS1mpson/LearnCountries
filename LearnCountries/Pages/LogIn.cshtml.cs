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
        public IActionResult OnPost()
        {
           Email = Request.Form["email"];
           Password = Request.Form["pass"];
           
           if(ModelState.IsValid)
            {
                User user = _userRepository.GetUser(Email,Password);
                if(user != null)
                {
                    Authenticate(Email);        // аутентифицируем
                    if(user.UserAccess == 0)
                        return RedirectToPage("UserPage",new {id = user.Id});
                    else
                        return RedirectToPage("AdminPage",new {id = user.Id});

                }
                //ModelState.AddModelError("","Некорректные логин и(или) пароль");
            }
            return Redirect("/Register");
        }

        public IActionResult Login()
        {
            if(ModelState.IsValid)
            {
                User user = _userRepository.GetUser(Email,Password);
                if(user != null)
                {
                    Authenticate(Email);        // аутентифицируем

                    return RedirectToAction("~/UserPage");
                }
                ModelState.AddModelError("","Некорректные логин и(или) пароль");
            }
            return RedirectToAction("/UserPage");
        }
        private void Authenticate(string email)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,email)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims,"ApplicationCoockie"
                                            ,ClaimsIdentity.DefaultNameClaimType,ClaimsIdentity.DefaultRoleClaimType);

            // установка аутентификационных куки
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(id));
        }
    }
}
