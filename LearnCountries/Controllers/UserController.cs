using LearnCountries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnCountries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
            =>_userRepository=userRepository;

         
    }
}