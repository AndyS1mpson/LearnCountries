using System;
using System.Collections.Generic;
using LearnCountries.Interfaces;
using LearnCountries.Models;
using System.Linq;

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
        public void DeleteUser(string name)
            {
                User userToDelete=_db.Users.FirstOrDefault(x=>x.Name==name);
                if(userToDelete==null)
                    throw new NullReferenceException("User is not exist");
                _db.Users.Remove(userToDelete);
                _db.SaveChanges();
            }

        public User GetUser(string name)
            =>_db.Users.FirstOrDefault(x => x.Name == name);

        public IEnumerable<User> GetUsers()
            =>_db.Users.Where(x=>true).ToList();

        public void UpdateUser(User user)
            {
                User userForUpdate=_db.Users.FirstOrDefault(x=>x.Name==user.Name);
                if(userForUpdate == null)
                    throw new NullReferenceException("User isn't exist");
                _db.Users.Update(userForUpdate);
            }
    }
}