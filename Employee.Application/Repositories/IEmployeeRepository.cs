using EmployeeApplication.Models.Entities;

namespace EmployeeApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id, CancellationToken token = default);// nullable becasue maybe it will not find the employee
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token = default);
        Task<bool> CreateAsync(Employee employee, CancellationToken token = default);
        Task<bool> UpdateAsync(Employee employee, CancellationToken token = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken token = default);
        Task<bool> ExistsByIdAsync(int id, CancellationToken token = default);
    }
}
