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
    public class AirplaneController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public AirplaneController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Airplane
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneDto>>> GetAirplane()
        {
            return await _context.Airplane.ToListAsync();
        }

        // GET: api/Airplane/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneDto>> GetAirplaneDto(string id)
        {
            var airplaneDto = await _context.Airplane.FindAsync(id);

            if (airplaneDto == null)
            {
                return NotFound();
            }

            return airplaneDto;
        }

        // PUT: api/Airplane/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplaneDto(string id, AirplaneDto airplaneDto)
        {
            if (id != airplaneDto.Registration)
            {
                return BadRequest();
            }

            _context.Entry(airplaneDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneDtoExists(id))
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

        // POST: api/Airplane
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirplaneDto>> PostAirplaneDto(AirplaneDto airplaneDto)
        {
            _context.Airplane.Add(airplaneDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AirplaneDtoExists(airplaneDto.Registration))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAirplaneDto", new { id = airplaneDto.Registration }, airplaneDto);
        }

        // DELETE: api/Airplane/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirplaneDto(string id)
        {
            var airplaneDto = await _context.Airplane.FindAsync(id);
            if (airplaneDto == null)
            {
                return NotFound();
            }

            _context.Airplane.Remove(airplaneDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirplaneDtoExists(string id)
        {
            return _context.Airplane.Any(e => e.Registration == id);
        }
    }
}
