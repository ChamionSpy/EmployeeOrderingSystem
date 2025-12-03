
using EmployeeOrderingSystem.Models;

namespace EmployeeOrderingSystem.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);
        Task<string?> GetAllEmployeesAsync();
        Task<string?> GetEmployeeByIdAsync(int id);
    }
}
