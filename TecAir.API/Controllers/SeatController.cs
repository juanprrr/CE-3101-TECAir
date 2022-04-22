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
    public class SeatController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public SeatController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Seat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatDto>>> GetSeat()
        {
            return await _context.Seat.ToListAsync();
        }

        // GET: api/Seat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatDto>> GetSeatDto(int id)
        {
            var seatDto = await _context.Seat.FindAsync(id);

            if (seatDto == null)
            {
                return NotFound();
            }

            return seatDto;
        }

        // PUT: api/Seat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatDto(int id, SeatDto seatDto)
        {
            if (id != seatDto.Number)
            {
                return BadRequest();
            }

            _context.Entry(seatDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatDtoExists(id))
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

        // POST: api/Seat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatDto>> PostSeatDto(SeatDto seatDto)
        {
            _context.Seat.Add(seatDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatDto", new { id = seatDto.Number }, seatDto);
        }

        // DELETE: api/Seat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatDto(int id)
        {
            var seatDto = await _context.Seat.FindAsync(id);
            if (seatDto == null)
            {
                return NotFound();
            }

            _context.Seat.Remove(seatDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatDtoExists(int id)
        {
            return _context.Seat.Any(e => e.Number == id);
        }
    }
}
