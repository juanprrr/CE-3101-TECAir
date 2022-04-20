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
    public class RouteController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public RouteController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Route
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteDto>>> GetRoute()
        {
            return await _context.Route.ToListAsync();
        }

        // GET: api/Route/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDto>> GetRouteDto(int id)
        {
            var routeDto = await _context.Route.FindAsync(id);

            if (routeDto == null)
            {
                return NotFound();
            }

            return routeDto;
        }

        // PUT: api/Route/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteDto(int id, RouteDto routeDto)
        {
            if (id != routeDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(routeDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteDtoExists(id))
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

        // POST: api/Route
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RouteDto>> PostRouteDto(RouteDto routeDto)
        {
            _context.Route.Add(routeDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteDto", new { id = routeDto.Id }, routeDto);
        }

        // DELETE: api/Route/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteDto(int id)
        {
            var routeDto = await _context.Route.FindAsync(id);
            if (routeDto == null)
            {
                return NotFound();
            }

            _context.Route.Remove(routeDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteDtoExists(int id)
        {
            return _context.Route.Any(e => e.Id == id);
        }
    }
}
