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

        public async Task<bool> CreateAsync(Employee employee, CancellationToken token = default)
        {
            await dbContext.AddAsync(employee,token);
            await dbContext.SaveChangesAsync(token);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken token = default)
        {
            var user = await dbContext.Employees.FindAsync(id, token);
            if (user is not null)
            {
                dbContext.Employees.Remove(user);
                await dbContext.SaveChangesAsync(token);
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsByIdAsync(int id, CancellationToken token = default)
        {
            return await dbContext.Employees.AnyAsync(e => e.Id == id, token);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token = default)
        {
            return await dbContext.Employees.ToArrayAsync(token);
        }

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task<bool> UpdateAsync(Employee employee, CancellationToken token = default)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id, token);

            if (result is not null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Phone = employee.Phone;
                result.Salary = employee.Salary;
                result.Email = employee.Email;
                result.IsDeleted = employee.IsDeleted;

                await dbContext.SaveChangesAsync(token);
                return true;
            }

            return false;
        }
    }
}
