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
    public class AeroportController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public AeroportController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Aeroport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AeroportDto>>> GetAeroport()
        {
            return await _context.Aeroport.ToListAsync();
        }

        // GET: api/Aeroport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AeroportDto>> GetAeroportDto(int id)
        {
            var aeroportDto = await _context.Aeroport.FindAsync(id);

            if (aeroportDto == null)
            {
                return NotFound();
            }

            return aeroportDto;
        }

        // PUT: api/Aeroport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroportDto(int id, AeroportDto aeroportDto)
        {
            if (id != aeroportDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(aeroportDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportDtoExists(id))
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

        // POST: api/Aeroport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AeroportDto>> PostAeroportDto(AeroportDto aeroportDto)
        {
            _context.Aeroport.Add(aeroportDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAeroportDto", new { id = aeroportDto.Id }, aeroportDto);
        }

        // DELETE: api/Aeroport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroportDto(int id)
        {
            var aeroportDto = await _context.Aeroport.FindAsync(id);
            if (aeroportDto == null)
            {
                return NotFound();
            }

            _context.Aeroport.Remove(aeroportDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportDtoExists(int id)
        {
            return _context.Aeroport.Any(e => e.Id == id);
        }
    }
}
