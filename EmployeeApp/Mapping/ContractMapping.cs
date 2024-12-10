using Contracts.Requests;
using Contracts.Responses;
using EmployeeApp.Models.Entities;

namespace EmployeeApp.Mapping
{
    public static class ContractMapping
    {
        public static Employee MapToEmployee(this CreateEmployeeRequest request)
        {
            return new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Salary = request.Salary
            };
        }
        public static Employee MaptoEmployee(this UpdateEmployeeRequest request, int id)
        {
            return new Employee()
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Salary = request.Salary,
                IsDeleted = request.IsDeleted
            };
        }
        public static EmployeeResponse MapToResponse(this Employee employee)
        {
            return new EmployeeResponse()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary,
                IsDeleted = employee.IsDeleted
            };
        }

        public static EmployeesResponse MapToResponse(this IEnumerable<Employee> employees)
        {
            return new EmployeesResponse()
            {
                Items = employees.Select(MapToResponse)
            };
        }
    }
}
