using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCountries.Models
{
    public enum Access{user=0,admin=1}

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name {get; set; } 
        [Required]
        public string SurName {get; set; }
        [Required]
        public Access UserAccess{get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int Score { get; set; }
        public int TaskSettings{get; set; }
    }
}
