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
    public class OriginController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public OriginController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Origin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OriginDto>>> GetOrigin()
        {
            return await _context.Origin.ToListAsync();
        }

        // GET: api/Origin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OriginDto>> GetOriginDto(int id)
        {
            var originDto = await _context.Origin.FindAsync(id);

            if (originDto == null)
            {
                return NotFound();
            }

            return originDto;
        }

        // PUT: api/Origin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOriginDto(int id, OriginDto originDto)
        {
            if (id != originDto.Id_aeroport)
            {
                return BadRequest();
            }

            _context.Entry(originDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginDtoExists(id))
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

        // POST: api/Origin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OriginDto>> PostOriginDto(OriginDto originDto)
        {
            _context.Origin.Add(originDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOriginDto", new { id = originDto.Id_aeroport }, originDto);
        }

        // DELETE: api/Origin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOriginDto(int id)
        {
            var originDto = await _context.Origin.FindAsync(id);
            if (originDto == null)
            {
                return NotFound();
            }

            _context.Origin.Remove(originDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OriginDtoExists(int id)
        {
            return _context.Origin.Any(e => e.Id_aeroport == id);
        }
    }
}
