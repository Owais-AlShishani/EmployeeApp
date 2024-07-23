using EmployeeApp.Data;
using EmployeeApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(Employee employee)
        {
            var res = await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var user = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (user is not null)
            {
                var value = dbContext.Employees.Remove(user);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToArrayAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            var user = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return user;
        }

        public async Task<bool> UpdateAsync(Guid Id, Employee employee)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == Id);

            if (result is not null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Phone = employee.Phone;
                result.Salary = employee.Salary;
                result.Address = employee.Address;
                result.Email = employee.Email;
                result.IsDeleted = employee.IsDeleted;
                result.UpdatedById = new Guid();// should be changed
                result.UpdatedDate = DateTime.Now;

                if (result.Id != new Guid())
                {
                    result.Id = Id;
                }
                int affected = await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }// TODO complete the return data like in the book
    }
}
