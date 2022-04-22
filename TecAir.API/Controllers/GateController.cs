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
    public class GateController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public GateController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Gate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GateDto>>> GetGate()
        {
            return await _context.Gate.ToListAsync();
        }

        // GET: api/Gate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GateDto>> GetGateDto(string id)
        {
            var gateDto = await _context.Gate.FindAsync(id);

            if (gateDto == null)
            {
                return NotFound();
            }

            return gateDto;
        }

        // PUT: api/Gate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGateDto(string id, GateDto gateDto)
        {
            if (id != gateDto.Number)
            {
                return BadRequest();
            }

            _context.Entry(gateDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateDtoExists(id))
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

        // POST: api/Gate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GateDto>> PostGateDto(GateDto gateDto)
        {
            _context.Gate.Add(gateDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GateDtoExists(gateDto.Number))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGateDto", new { id = gateDto.Number }, gateDto);
        }

        // DELETE: api/Gate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGateDto(string id)
        {
            var gateDto = await _context.Gate.FindAsync(id);
            if (gateDto == null)
            {
                return NotFound();
            }

            _context.Gate.Remove(gateDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GateDtoExists(string id)
        {
            return _context.Gate.Any(e => e.Number == id);
        }
    }
}
