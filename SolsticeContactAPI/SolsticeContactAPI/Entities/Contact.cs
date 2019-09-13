using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeContactAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
