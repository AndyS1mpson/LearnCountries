using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCountries.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        //[EmailAddress]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }
        public int Score { get; set; }
    }
}
