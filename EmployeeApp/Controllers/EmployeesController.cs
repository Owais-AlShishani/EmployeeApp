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
            var employees = await _employeeRepository.GetAllAsync();
            if (employees is null)
            {
                return NotFound();
            }
            var emoloyeesResponse = employees.MapToResponse();
            return Ok(emoloyeesResponse);
        }


        [HttpGet(ApiEndpoints.Employees.Get)]
        public async Task<IActionResult> Get(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            var employeeResponse = employee.MapToResponse();
            return Ok(employeeResponse);
        }


        [HttpPost(ApiEndpoints.Employees.Create)]
        public async Task<IActionResult> Create(CreateEmployeeRequest request)
        {
            var employee = request.MapToEmployee();
            await _employeeRepository.CreateAsync(employee);
            var employeeResponse = employee.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employeeResponse);
        }


        [HttpPut(ApiEndpoints.Employees.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            var employee = request.MaptoEmployee(id);
            var updateEmployee = await _employeeRepository.UpdateAsync(employee);
            //var response  = updateEmployee.MapToResponse();
            return Ok(updateEmployee);// and here add response
        }


        [HttpDelete(ApiEndpoints.Employees.Delete)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _employeeRepository.DeleteByIdAsync(id);
            return Ok(result);
        }
    }// TODO complete the mapping for the responses and test it 
}
