using EmployeeApp.Repositories;
using EmployeeApplication.Models.Entities;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<bool> CreateAsync(Employee employee)
        {
            return await employeeRepository.CreateAsync(employee);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await employeeRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await employeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            var employeeExist = await employeeRepository.ExistsByIdAsync(employee.Id);
            if (!employeeExist)
            {
                return null;
            }
            await employeeRepository.UpdateAsync(employee);
            return employee;
        }
    }
}
