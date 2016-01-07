using CamCecilCom.Models;
using Microsoft.Data.Entity;
using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CamCecilCom.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        // Database Sets
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
