using System.Collections.Generic;
using LearnCountries.Models;

namespace LearnCountries.Interfaces
{
    public interface  IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(string name);
        public void CreateUser(User user);
        public void DeleteUser(string name);
        public void UpdateUser(User user);
    }
}