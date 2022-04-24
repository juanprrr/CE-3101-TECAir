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
    public class TravelController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public TravelController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Travel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelDto>>> GetTravel()
        {
            return await _context.Travel.ToListAsync();
        }

        // GET: api/Travel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelDto>> GetTravelDto(int id)
        {
            var travelDto = await _context.Travel.FindAsync(id);

            if (travelDto == null)
            {
                return NotFound();
            }

            return travelDto;
        }

        // PUT: api/Travel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelDto(int id, TravelDto travelDto)
        {
            if (id != travelDto.Number)
            {
                return BadRequest();
            }

            _context.Entry(travelDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelDtoExists(id))
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

        // POST: api/Travel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelDto>> PostTravelDto(TravelDto travelDto)
        {
            _context.Travel.Add(travelDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelDto", new { id = travelDto.Number }, travelDto);
        }

        // DELETE: api/Travel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelDto(int id)
        {
            var travelDto = await _context.Travel.FindAsync(id);
            if (travelDto == null)
            {
                return NotFound();
            }

            _context.Travel.Remove(travelDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelDtoExists(int id)
        {
            return _context.Travel.Any(e => e.Number == id);
        }
    }
}
