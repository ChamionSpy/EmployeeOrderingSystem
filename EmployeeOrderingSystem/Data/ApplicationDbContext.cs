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
    }
}
