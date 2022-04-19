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
    public class FlightController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public FlightController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Flight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlight()
        {
            return await _context.Flight.ToListAsync();
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetFlightDto(int id)
        {
            var flightDto = await _context.Flight.FindAsync(id);

            if (flightDto == null)
            {
                return NotFound();
            }

            return flightDto;
        }

        // PUT: api/Flight/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightDto(int id, FlightDto flightDto)
        {
            if (id != flightDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDtoExists(id))
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

        // POST: api/Flight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightDto>> PostFlightDto(FlightDto flightDto)
        {
            _context.Flight.Add(flightDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightDto", new { id = flightDto.Id }, flightDto);
        }

        // DELETE: api/Flight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightDto(int id)
        {
            var flightDto = await _context.Flight.FindAsync(id);
            if (flightDto == null)
            {
                return NotFound();
            }

            _context.Flight.Remove(flightDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightDtoExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
