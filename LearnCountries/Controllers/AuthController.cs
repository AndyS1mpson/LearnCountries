using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyApp.Namespace;

namespace LearnCountries.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository _userRepository;
        AuthController(IUserRepository userRepository)
            =>  _userRepository = userRepository;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("LogIn/Check")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _userRepository.GetUserAsync(model.Email,model.Password);
                if(user != null)
                {
                    await Authenticate(model.Email);        // аутентифицируем

                    return RedirectToAction("~/UserPage");
                }
                ModelState.AddModelError("","Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string email)
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
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(id));
        }
    }
}