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
    public class RoleController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public RoleController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRole()
        {
            return await _context.Role.ToListAsync();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleDto(int id)
        {
            var roleDto = await _context.Role.FindAsync(id);

            if (roleDto == null)
            {
                return NotFound();
            }

            return roleDto;
        }

        // PUT: api/Role/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleDto(int id, RoleDto roleDto)
        {
            if (id != roleDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(roleDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleDtoExists(id))
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

        // POST: api/Role
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleDto>> PostRoleDto(RoleDto roleDto)
        {
            _context.Role.Add(roleDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleDto", new { id = roleDto.Id }, roleDto);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleDto(int id)
        {
            var roleDto = await _context.Role.FindAsync(id);
            if (roleDto == null)
            {
                return NotFound();
            }

            _context.Role.Remove(roleDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleDtoExists(int id)
        {
            return _context.Role.Any(e => e.Id == id);
        }
    }
}
