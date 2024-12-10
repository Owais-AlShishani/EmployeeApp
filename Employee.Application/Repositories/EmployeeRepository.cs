using EmployeeApp.Data;
using EmployeeApplication.Models.Entities;
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
            await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var user = await dbContext.Employees.FindAsync(id);
            if (user is not null)
            {
                dbContext.Employees.Remove(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await dbContext.Employees.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToArrayAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result is not null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Phone = employee.Phone;
                result.Salary = employee.Salary;
                result.Email = employee.Email;
                result.IsDeleted = employee.IsDeleted;

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
