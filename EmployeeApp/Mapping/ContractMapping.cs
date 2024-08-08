using EmployeeApp.Models.Entities;
using EmployeeApp.Models.Requests;
using EmployeeApp.Models.Responses;

namespace EmployeeApp.Mapping
{
    public static class ContractMapping
    {
        public static Employee MapToEmployee(this CreateEmployeeRequest request)
        {
            return new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                CreatedById = request.CreatedById,
                CreatedDate = DateTime.Now,
                Salary = request.Salary
            };
        }
        public static Employee MaptoEmployee(this UpdateEmployeeRequest request, Guid id)
        {
            return new Employee()
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                UpdatedById = Guid.NewGuid(),
                UpdatedDate = DateTime.Now,
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
                Email = employee.LastName,
                Phone = employee.Phone,
                Address = employee.Address,
                CreatedById = employee.CreatedById,
                CreatedDate = employee.CreatedDate,
                UpdatedById = employee.UpdatedById,
                UpdatedDate = employee.UpdatedDate,
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
