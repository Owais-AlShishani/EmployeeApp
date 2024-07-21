using EmployeeApp.Models.Entities;
using EmployeeApp.Models.Requests;

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
    }
}
