using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeContactAPI.Entities
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
