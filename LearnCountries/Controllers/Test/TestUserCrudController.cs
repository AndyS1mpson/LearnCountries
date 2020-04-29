using System.Collections.Generic;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnCountries.Controllers.Test
{
    [ApiController]
    [Route("api/user/test")]
    public class TestUserCrudController
    {
        private IUserRepository _userRepository;
        public TestUserCrudController(IUserRepository userRepository)
            =>_userRepository=userRepository;
        
        [HttpGet]
        public IEnumerable<User> GetUsers()
            => _userRepository.GetUsers();

        [HttpGet("{username}")]
        // public User GetUser(string userName)
        //     =>_userRepository.GetUser(userName);
        [HttpDelete("{username}")]
        public void DeleteUser(string userName)
            =>_userRepository.DeleteUser(userName);
        [HttpPut]
        public void PutUser([FromBody]User user)
            =>_userRepository.UpdateUser(user);
        [HttpPost]
        public void PostUser([FromBody]User user)
            =>_userRepository.CreateUser(user);
    }
}