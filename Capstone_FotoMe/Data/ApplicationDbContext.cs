using System;
using System.Collections.Generic;
using System.Text;
using Capstone_FotoMe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone_FotoMe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       

        public DbSet<PhotoEnthusiast> PhotoEnthusiasts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhotoRequestPost> PhotoRequestPosts { get; set; }

        public DbSet<Friend> Friends { get; set; }

    }
}
