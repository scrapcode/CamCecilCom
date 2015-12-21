using Microsoft.Data.Entity;
using System;

namespace CamCecilCom.Data
{
    public class AppDbContext : DbContext
    {
        // Database Sets


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
