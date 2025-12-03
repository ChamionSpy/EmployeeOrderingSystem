using EmployeeOrderingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeOrderingSystem.Data
{
    // ApplicationDbContext class inheriting from DbContext
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // set tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        // Configure entity relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Make EmployeeNumber unique
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeNumber)
                .IsUnique();

            // Configure one-to-many relationship between Restaurant and MenuItem
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)           // Each MenuItem has one Restaurant
                .WithMany(r => r.MenuItems)          // Each Restaurant can have many MenuItems
                .HasForeignKey(m => m.RestaurantId)  // Foreign key in MenuItem
                .OnDelete(DeleteBehavior.Cascade);   // Delete MenuItems if Restaurant is deleted
        }
    }
}
