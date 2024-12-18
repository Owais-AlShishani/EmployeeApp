using Contracts.Requests;
using EmployeeApp.Mapping;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet(ApiEndpoints.Employees.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var employees = await employeeService.GetAllAsync();
            if (employees is null)
            {
                return NotFound();
            }
            var emoloyeesResponse = employees.MapToResponse();
            return Ok(emoloyeesResponse);
        }


        [HttpGet(ApiEndpoints.Employees.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await employeeService.GetByIdAsync(id);
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
            await employeeService.CreateAsync(employee);
            var employeeResponse = employee.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employeeResponse);
        }


        [HttpPut(ApiEndpoints.Employees.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeRequest request)
        {
            var employee = request.MaptoEmployee(id);
            var updateEmployee = await employeeService.UpdateAsync(employee);
            if (updateEmployee is null)
            {
                return NotFound();
            }
            var employeeResponse = updateEmployee.MapToResponse();
            return Ok(employeeResponse);
        }


        [HttpDelete(ApiEndpoints.Employees.Delete)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var deleted = await employeeService.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
