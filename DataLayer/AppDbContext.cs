using Microsoft.EntityFrameworkCore;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(b => b.IsEnable)
                .HasDefaultValue(true);

            modelBuilder.Entity<Category>()
                .Property(b => b.IsEnable)
                .HasDefaultValue(true);
        }
    }
}
