using EmployeeApp.Mapping;
using EmployeeApp.Models.Requests;
using EmployeeApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet(ApiEndpoints.Employees.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet(ApiEndpoints.Employees.Get)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _employeeRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost(ApiEndpoints.Employees.Create)]
        public async Task<IActionResult> Create(CreateEmployeeRequest request)
        {
            var employee = request.MapToEmployee();
            await _employeeRepository.CreateAsync(employee);
            return Created($"/{ApiEndpoints.Employees.Create}/{employee.Id}", employee);
        }


        [HttpPut(ApiEndpoints.Employees.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            var employee = request.MaptoEmployee(id);
            var result = await _employeeRepository.UpdateAsync(id, employee);
            return Ok(result);
        }

        [HttpDelete(ApiEndpoints.Employees.Delete)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _employeeRepository.DeleteByIdAsync(id);
            return Ok(result);
        }
    }// TODO complete the mapping for the response
}
