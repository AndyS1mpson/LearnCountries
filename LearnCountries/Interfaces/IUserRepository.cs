using System.Collections.Generic;
using System.Threading.Tasks;
using LearnCountries.Models;

namespace LearnCountries.Interfaces
{
    public interface  IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(string email,string password);
        public User GetUserByEmail(string email);
        public void CreateUser(User user);
        public void DeleteUser(string name);
        public void UpdateUser(User user);

        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserAsync(string email,string password);
        public Task CreateUserAsync(User user);
        public Task DeleteUserAsync(string name);
        public Task UpdateUserAsync(User user);
    }
}