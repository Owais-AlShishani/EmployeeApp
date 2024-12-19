using EmployeeApp.Repositories;
using EmployeeApplication.Models.Entities;
using FluentValidation;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IValidator<Employee> employeeValidator;

        public EmployeeService(IEmployeeRepository employeeRepository, IValidator<Employee> employeeValidator)
        {
            this.employeeRepository = employeeRepository;
            this.employeeValidator = employeeValidator;
        }

        public async Task<bool> CreateAsync(Employee employee, CancellationToken token = default)
        {
            await employeeValidator.ValidateAndThrowAsync(employee, cancellationToken: token);
            return await employeeRepository.CreateAsync(employee,token);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token = default)
        {
            return await employeeRepository.DeleteByIdAsync(id,token);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync( CancellationToken token = default)
        {
            return await employeeRepository.GetAllAsync(token);
        }

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await employeeRepository.GetByIdAsync(id,token);
        }

        public async Task<Employee?> UpdateAsync(Employee employee, CancellationToken token = default)
        {
            await employeeValidator.ValidateAndThrowAsync(employee, cancellationToken: token);

            var employeeExist = await employeeRepository.ExistsByIdAsync(employee.Id,token);
            if (!employeeExist)
            {
                return null;
            }
            await employeeRepository.UpdateAsync(employee,token);
            return employee;
        }
    }
}
