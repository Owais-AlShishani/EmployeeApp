using EmployeeApp.Models.Entities;

namespace EmployeeApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);// nullable becasue maybe it will not find the employee
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<bool> CreateAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
    }
}
