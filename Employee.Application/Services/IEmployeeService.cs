using EmployeeApplication.Models.Entities;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<bool> CreateAsync(Employee employee);
        Task<Employee?> UpdateAsync(Employee employee);
        Task<bool> DeleteByIdAsync(int id);
    }
}
