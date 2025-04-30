using EMS.API.Models;
using EMS.API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return BadRequest();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            var created = await _employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest("ID Mismatch!");

            try
            {
                await _employeeService.UpdateAsync(employee);

            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

            return NoContent();
        }


    }
}
