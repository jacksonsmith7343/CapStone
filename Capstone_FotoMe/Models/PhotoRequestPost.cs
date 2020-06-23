using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class PhotoRequestPost
    {
        [Key]
        public int PhotoRequestPostId { get; set; }
        
        public DateTime DateOfRequest { get; set; }

        public int TimeRequired { get; set; }

        public int MaxPrice { get; set; }

        public bool IsAccepted { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("PhotoEnthusiastId")]
        public string PhotoEnthusiastId { get; set; }
        public PhotoEnthusiast PhotoEnthusiast { get; set; }
        


    }
}
