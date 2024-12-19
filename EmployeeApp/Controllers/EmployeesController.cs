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
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var employees = await employeeService.GetAllAsync(token);
            if (employees is null)
            {
                return NotFound();
            }
            var emoloyeesResponse = employees.MapToResponse();
            return Ok(emoloyeesResponse);
        }


        [HttpGet(ApiEndpoints.Employees.Get)]
        public async Task<IActionResult> Get(int id, CancellationToken token)
        {
            var employee = await employeeService.GetByIdAsync(id, token);
            if (employee is null)
            {
                return NotFound();
            }
            var employeeResponse = employee.MapToResponse();
            return Ok(employeeResponse);
        }


        [HttpPost(ApiEndpoints.Employees.Create)]
        public async Task<IActionResult> Create(CreateEmployeeRequest request, CancellationToken token)
        {
            var employee = request.MapToEmployee();
            await employeeService.CreateAsync(employee, token);
            var employeeResponse = employee.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employeeResponse);
        }


        [HttpPut(ApiEndpoints.Employees.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeRequest request, CancellationToken token)
        {
            var employee = request.MaptoEmployee(id);
            var updateEmployee = await employeeService.UpdateAsync(employee, token);
            if (updateEmployee is null)
            {
                return NotFound();
            }
            var employeeResponse = updateEmployee.MapToResponse();
            return Ok(employeeResponse);
        }


        [HttpDelete(ApiEndpoints.Employees.Delete)]
        public async Task<IActionResult> DeleteById(int id, CancellationToken token)
        {
            var deleted = await employeeService.DeleteByIdAsync(id, token);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
