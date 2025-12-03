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

        // set Employee table
        public DbSet<Employee> Employees { get; set; }

        // Configure entity relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Make EmployeeNumber unique
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeNumber)
                .IsUnique();
        }
    }
}
