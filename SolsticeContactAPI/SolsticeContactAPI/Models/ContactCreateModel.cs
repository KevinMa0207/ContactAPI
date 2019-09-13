using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeContactAPI.Models
{
    public class ContactCreateModel
    {
        [Required]
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public string WorkPhoneNumber { get; set; }
        [Required]
        public string PersonalPhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
