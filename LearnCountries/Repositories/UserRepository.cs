using System;
using System.Collections.Generic;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCountries.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db=db;
        }
        public void CreateUser(User user)
            { 
                _db.Users.AddRange(user);
                _db.SaveChangesAsync();
            }

        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string name)
            {
                User userToDelete=_db.Users.FirstOrDefault(x=>x.UserName==name);
                if(userToDelete==null)
                    throw new NullReferenceException("User is not exist");
                _db.Users.Remove(userToDelete);
                _db.SaveChanges();
            }

        public Task DeleteUserAsync(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email,string password)
            =>_db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

        public Task<User> GetUserAsync(string email,string Password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
            =>_db.Users.Where(x=>true).ToList();

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
            {
                User userForUpdate=_db.Users.FirstOrDefault(x=>x.UserName==user.UserName);
                if(userForUpdate == null)
                    throw new NullReferenceException("User isn't exist");
                
                 userForUpdate.UserName=user.UserName;
                 userForUpdate.Password=user.Password;
                 userForUpdate.UserAccess=user.UserAccess;
                 userForUpdate.Email=user.Email;
                 userForUpdate.Score=user.Score;
                 userForUpdate.TaskSettings=user.TaskSettings;
                
                _db.SaveChangesAsync();
            }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}