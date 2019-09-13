using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeContactAPI.Models
{
    public class ContactViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public int? AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
