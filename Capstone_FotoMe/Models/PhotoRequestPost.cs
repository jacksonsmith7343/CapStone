using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class PhotoRequestPost
    {
        public DateTime DateOfRequest { get; set; }

        public int TimeRequired { get; set; }

        public int MaxPrice { get; set; }

        public bool IsAccepted { get; set; }

        [ForeignKey("IdentityUser")]
        public int AddressId { get; set; }

        public int PhotoEnthusiastId { get; set; }


    }
}
