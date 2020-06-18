﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class PhotoEnthusiast
    {
        [Key]
        public int PhotoEnthusiastId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int PriceForService { get; set; }

        public double Rating { get; set; }

        public string PostRequest { get; set; }

       public double Money { get; set; }



        [ForeignKey("IdentityUser")]
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public string IdentityUserId { get; internal set; }
    }
}