using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCountries.Models
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int score { get; set; }
    }
}
