using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeContactAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

    }
}
