using EmployeeOrderingSystem.Data;
using EmployeeOrderingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeOrderingSystem.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // Get employee by ID
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        // Get employee by employee number
        public async Task<Employee?> GetEmployeeByNumberAsync(string employeeNumber)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber);
        }

        // Create new employee
        public async Task CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        // Update employee
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        // Delete employee
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
