using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Models
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }
        public bool IsAccepted { get; set; }
        
        [ForeignKey("PhotoEnthusiast")]
        public int RequesterPhotoEnthusiastId { get; set; }
        
        [ForeignKey("PhotoEnthusiast")]
        public int RequesteePhotoEnthusiastId { get; set; }

    }
}
