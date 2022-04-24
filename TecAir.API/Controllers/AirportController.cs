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
    public class AirportController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public AirportController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Airport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAirport()
        {
            return await _context.Airport.ToListAsync();
        }

        // GET: api/Airport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportDto>> GetAirportDto(int id)
        {
            var airportDto = await _context.Airport.FindAsync(id);

            if (airportDto == null)
            {
                return NotFound();
            }

            return airportDto;
        }

        // PUT: api/Airport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirportDto(int id, AirportDto airportDto)
        {
            if (id != airportDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(airportDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportDtoExists(id))
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

        // POST: api/Airport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirportDto>> PostAirportDto(AirportDto airportDto)
        {
            _context.Airport.Add(airportDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirportDto", new { id = airportDto.Id }, airportDto);
        }

        // DELETE: api/Airport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirportDto(int id)
        {
            var airportDto = await _context.Airport.FindAsync(id);
            if (airportDto == null)
            {
                return NotFound();
            }

            _context.Airport.Remove(airportDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirportDtoExists(int id)
        {
            return _context.Airport.Any(e => e.Id == id);
        }
    }
}
