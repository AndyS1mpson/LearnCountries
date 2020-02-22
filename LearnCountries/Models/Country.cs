using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCountries.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CapitalName { get; set; }
        [Required]
        public string Flag { get; set; }
    }
}
