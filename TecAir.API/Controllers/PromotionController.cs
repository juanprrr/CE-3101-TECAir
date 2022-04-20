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
    public class PromotionController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public PromotionController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Promotion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetPromotion()
        {
            return await _context.Promotion.ToListAsync();
        }

        // GET: api/Promotion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDto>> GetPromotionDto(int id)
        {
            var promotionDto = await _context.Promotion.FindAsync(id);

            if (promotionDto == null)
            {
                return NotFound();
            }

            return promotionDto;
        }

        // PUT: api/Promotion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotionDto(int id, PromotionDto promotionDto)
        {
            if (id != promotionDto.Code)
            {
                return BadRequest();
            }

            _context.Entry(promotionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionDtoExists(id))
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

        // POST: api/Promotion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PromotionDto>> PostPromotionDto(PromotionDto promotionDto)
        {
            _context.Promotion.Add(promotionDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotionDto", new { id = promotionDto.Code }, promotionDto);
        }

        // DELETE: api/Promotion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotionDto(int id)
        {
            var promotionDto = await _context.Promotion.FindAsync(id);
            if (promotionDto == null)
            {
                return NotFound();
            }

            _context.Promotion.Remove(promotionDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromotionDtoExists(int id)
        {
            return _context.Promotion.Any(e => e.Code == id);
        }
    }
}
