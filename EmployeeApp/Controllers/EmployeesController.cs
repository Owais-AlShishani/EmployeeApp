using EmployeeApp.Models.Entities;
using EmployeeApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Route("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _employeeRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            var result = await _employeeRepository.CreateAsync(employee);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            var result = await _employeeRepository.UpdateAsync(employee);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _employeeRepository.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}
