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
    public class UserController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public UserController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserDto(int id)
        {
            var userDto = await _context.User.FindAsync(id);

            if (userDto == null)
            {
                return NotFound();
            }

            return userDto;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDto(int id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDtoExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUserDto(UserDto userDto)
        {
            _context.User.Add(userDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDto", new { id = userDto.Id }, userDto);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDto(int id)
        {
            var userDto = await _context.User.FindAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }

            _context.User.Remove(userDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDtoExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
