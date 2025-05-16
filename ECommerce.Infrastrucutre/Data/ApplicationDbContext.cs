using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Models.Entities;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    { 
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemsOrdered> ItemsOrdereds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().Property(p => p.Status).HasConversion<string>();
            modelBuilder.Entity<User>().Property(p => p.UserType).HasConversion<string>();
        }
    }
}