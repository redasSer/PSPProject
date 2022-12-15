using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModifiersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ModifiersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Modifiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modifier>>> GetModifiers()
        {
            return await _context.Modifiers.ToListAsync();
        }

        // GET: api/Modifiers/5
        [HttpGet("{modifierId}")]
        public async Task<ActionResult<Modifier>> GetModifier(Guid modifierId)
        {
            var modifier = await _context.Modifiers.FindAsync(modifierId);

            if (modifier == null)
            {
                return NotFound();
            }

            return modifier;
        }

        // PUT: api/Modifiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{modifierId}")]
        public async Task<IActionResult> PutInventory(Guid modifierId, Modifier modifier)
        {
            if (modifierId != modifier.ModifierId)
            {
                return BadRequest();
            }

            _context.Entry(modifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModifierExists(modifierId))
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

        // POST: api/Modifiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modifier>> PostModifier(Modifier modifier)
        {
            modifier.ModifierId = new Guid();
            _context.Modifiers.Add(modifier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModifier", new { modifierId = modifier.ModifierId }, modifier);
        }

        // DELETE: api/Modifiers/5
        [HttpDelete("{modifierId}")]
        public async Task<IActionResult> DeleteModifier(Guid modifierId)
        {
            var modifier = await _context.Modifiers.FindAsync(modifierId);
            if (modifier == null)
            {
                return NotFound();
            }

            _context.Modifiers.Remove(modifier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModifierExists(Guid modifierId)
        {
            return _context.Modifiers.Any(e => e.ModifierId == modifierId);
        }
    }
}
