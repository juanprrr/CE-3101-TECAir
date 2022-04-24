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
    public class UniversityController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public UniversityController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/University
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityDto>>> GetUniversity()
        {
            return await _context.University.ToListAsync();
        }

        // GET: api/University/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityDto>> GetUniversityDto(int id)
        {
            var universityDto = await _context.University.FindAsync(id);

            if (universityDto == null)
            {
                return NotFound();
            }

            return universityDto;
        }

        // PUT: api/University/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversityDto(int id, UniversityDto universityDto)
        {
            if (id != universityDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(universityDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityDtoExists(id))
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

        // POST: api/University
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UniversityDto>> PostUniversityDto(UniversityDto universityDto)
        {
            _context.University.Add(universityDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversityDto", new { id = universityDto.Id }, universityDto);
        }

        // DELETE: api/University/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversityDto(int id)
        {
            var universityDto = await _context.University.FindAsync(id);
            if (universityDto == null)
            {
                return NotFound();
            }

            _context.University.Remove(universityDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversityDtoExists(int id)
        {
            return _context.University.Any(e => e.Id == id);
        }
    }
}
