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
    public class DestinationController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public DestinationController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Destination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinationDto>>> GetDestination()
        {
            return await _context.Destination.ToListAsync();
        }

        // GET: api/Destination/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinationDto>> GetDestinationDto(int id)
        {
            var destinationDto = await _context.Destination.FindAsync(id);

            if (destinationDto == null)
            {
                return NotFound();
            }

            return destinationDto;
        }

        // PUT: api/Destination/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinationDto(int id, DestinationDto destinationDto)
        {
            if (id != destinationDto.Id_airport)
            {
                return BadRequest();
            }

            _context.Entry(destinationDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationDtoExists(id))
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

        // POST: api/Destination
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DestinationDto>> PostDestinationDto(DestinationDto destinationDto)
        {
            _context.Destination.Add(destinationDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestinationDto", new { id = destinationDto.Id_airport }, destinationDto);
        }

        // DELETE: api/Destination/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinationDto(int id)
        {
            var destinationDto = await _context.Destination.FindAsync(id);
            if (destinationDto == null)
            {
                return NotFound();
            }

            _context.Destination.Remove(destinationDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinationDtoExists(int id)
        {
            return _context.Destination.Any(e => e.Id_airport == id);
        }
    }
}
