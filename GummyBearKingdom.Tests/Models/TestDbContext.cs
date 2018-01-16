using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GummyBearKingdom.Models;

namespace GummyBearKingdom.Tests.Models
{
    public class TestDbContext : GummyBearKingdomDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummybearkingdom_Test;uid=root;pwd=root;");
        }
    }
}
