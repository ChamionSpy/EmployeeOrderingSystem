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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

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

            // Configure Order-Employee relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)          // Each order belongs to one employee
                .WithMany(e => e.Orders)          // Each employee can have many orders
                .HasForeignKey(o => o.EmployeeId) // Foreign key in Order
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting employee if orders exist

            // Configure OrderItem-Order relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)           // Each OrderItem belongs to one Order
                .WithMany(o => o.OrderItems)      // Each Order can have many OrderItems
                .HasForeignKey(oi => oi.OrderId)  // Foreign key in OrderItem
                .OnDelete(DeleteBehavior.Cascade); // Delete OrderItems if Order is deleted

            // Configure OrderItem-MenuItem relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)        // Each OrderItem is linked to a MenuItem
                .WithMany()                        // No navigation from MenuItem needed
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting MenuItem if referenced in OrderItem
        }
    }
}
