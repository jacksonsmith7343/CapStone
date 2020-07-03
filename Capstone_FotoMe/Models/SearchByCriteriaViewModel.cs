using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class SearchByCriteriaViewModel
    {
        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "Rating")]
        public double? Rating { get; set; }

        [Display(Name = "Price")]
        public double? Price { get; set; }

       
       public bool SearchByCity { get; set; }

       public bool SearchByRating { get; set; }

       public bool SearchByPrice { get; set; }



    }
}
