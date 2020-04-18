using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries.Interfaces;
using LearnCountries.Models;
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
        public string img{get;set;}
        [BindProperty(Name="file",SupportsGet=true)]
        public IFormFile file{get;set;}
        public UserPageModel(IUserRepository userRepository)
            => _userRepository = userRepository;
        public void OnGet()
        {
            user = _userRepository.GetUserById(id);
            //img = new FileContentResult(user.Avatar,"image/png");
            img = string.Format("data:{0};base64,{1}", "image/jpeg", Convert.ToBase64String(user.Img));

        }
        public IActionResult OnPost()
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

    }
}
