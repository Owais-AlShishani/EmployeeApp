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
            //int result = await dbContext.AddAsync(employee);
            await dbContext.AddAsync(employee);
            int affected = await dbContext.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var user = await dbContext.Employees.FindAsync(id);
            if (user is not null)
            {
                //var value = dbContext.Employees.Remove(user);
                dbContext.Employees.Remove(user);
                int affected = await dbContext.SaveChangesAsync();
                return affected > 0;
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
            var user = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return user;
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


                if (result.Id != 0)
                {
                    result.Id = employee.Id;
                }
            }
            int affected = await dbContext.SaveChangesAsync();

            return affected > 0;
        }
    }
}
