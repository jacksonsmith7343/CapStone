using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public int AddressesId { get; internal set; }
    }
}
