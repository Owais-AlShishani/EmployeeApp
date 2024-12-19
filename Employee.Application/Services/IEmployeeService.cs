using EmployeeApplication.Models.Entities;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        Task<Employee?> GetByIdAsync(int id, CancellationToken token = default);
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token = default);
        Task<bool> CreateAsync(Employee employee, CancellationToken token = default);
        Task<Employee?> UpdateAsync(Employee employee, CancellationToken token = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken token = default);
    }
}
