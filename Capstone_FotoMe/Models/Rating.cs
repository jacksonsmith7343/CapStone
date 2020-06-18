using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class Rating
    {
        [key]
        public double RatingScore { get; set; }

        [ForeignKey("IdentityUser")]
        public int PhotoEnthusiastId { get; set; }

    }
}
