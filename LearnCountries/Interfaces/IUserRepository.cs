using System.Collections.Generic;
using LearnCountries.Models;

namespace LearnCountries.Interfaces
{
    public interface  IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(int id);
        public void CreateUser(User user);
        public void DeleteUser(int id);
        public void UpdateUser(User user);
    }
}