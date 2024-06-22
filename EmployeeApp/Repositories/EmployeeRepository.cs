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

        public Task<bool> CreateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteyIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public Task<Employee?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
