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
    public class ReservationController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ReservationController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservation()
        {
            return await _context.Reservation.ToListAsync();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservationDto(int id)
        {
            var reservationDto = await _context.Reservation.FindAsync(id);

            if (reservationDto == null)
            {
                return NotFound();
            }

            return reservationDto;
        }

        // PUT: api/Reservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationDto(int id, ReservationDto reservationDto)
        {
            if (id != reservationDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservationDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationDtoExists(id))
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

        // POST: api/Reservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationDto>> PostReservationDto(ReservationDto reservationDto)
        {
            _context.Reservation.Add(reservationDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationDto", new { id = reservationDto.Id }, reservationDto);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationDto(int id)
        {
            var reservationDto = await _context.Reservation.FindAsync(id);
            if (reservationDto == null)
            {
                return NotFound();
            }

            _context.Reservation.Remove(reservationDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationDtoExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}
