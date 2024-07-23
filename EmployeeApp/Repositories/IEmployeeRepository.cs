using EmployeeApp.Models.Entities;

namespace EmployeeApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(Guid id);// nullable becasue maybe it will not find the employee
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<bool> CreateAsync(Employee employee);
        Task<bool> UpdateAsync(Guid id, Employee employee);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
