using Microsoft.EntityFrameworkCore;

namespace LearnCountries.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
            Database.EnsureCreated();
        }
        public DbSet<User> Users {get;set;}
        public DbSet<Country> Countries {get;set;}
    }
}