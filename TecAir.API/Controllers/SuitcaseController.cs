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
    public class SuitcaseController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public SuitcaseController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Suitcase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuitcaseDto>>> GetSuitcase()
        {
            return await _context.Suitcase.ToListAsync();
        }

        // GET: api/Suitcase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuitcaseDto>> GetSuitcaseDto(int id)
        {
            var suitcaseDto = await _context.Suitcase.FindAsync(id);

            if (suitcaseDto == null)
            {
                return NotFound();
            }

            return suitcaseDto;
        }

        // PUT: api/Suitcase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuitcaseDto(int id, SuitcaseDto suitcaseDto)
        {
            if (id != suitcaseDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(suitcaseDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuitcaseDtoExists(id))
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

        // POST: api/Suitcase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuitcaseDto>> PostSuitcaseDto(SuitcaseDto suitcaseDto)
        {
            _context.Suitcase.Add(suitcaseDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuitcaseDto", new { id = suitcaseDto.Id }, suitcaseDto);
        }

        // DELETE: api/Suitcase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuitcaseDto(int id)
        {
            var suitcaseDto = await _context.Suitcase.FindAsync(id);
            if (suitcaseDto == null)
            {
                return NotFound();
            }

            _context.Suitcase.Remove(suitcaseDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuitcaseDtoExists(int id)
        {
            return _context.Suitcase.Any(e => e.Id == id);
        }
    }
}
