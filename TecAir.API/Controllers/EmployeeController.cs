#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecAir.API.Models;
using TecAir.API.Services;

namespace TecAir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public EmployeeController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeDto(int id)
        {
            var employeeDto = await _context.Employee.FindAsync(id);

            if (employeeDto == null)
            {
                return NotFound();
            }

            return employeeDto;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDto(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployeeDto(EmployeeDto employeeDto)
        {
            _context.Employee.Add(employeeDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDto", new { id = employeeDto.Id }, employeeDto);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDto(int id)
        {
            var employeeDto = await _context.Employee.FindAsync(id);
            if (employeeDto == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employeeDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDtoExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
