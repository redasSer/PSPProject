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
    public class InventoryUsageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryUsageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InventoryUsage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryUsage>>> GetInventoryUsage()
        {
            return await _context.InventoryUsage.ToListAsync();
        }

        // GET: api/InventoryUsage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryUsage>> GetInventoryUsage(Guid id)
        {
            var inventoryUsage = await _context.InventoryUsage.FindAsync(id);

            if (inventoryUsage == null)
            {
                return NotFound();
            }

            return inventoryUsage;
        }

        // PUT: api/InventoryUsage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(Guid id, InventoryUsage inventoryUsage)
        {
            if (id != inventoryUsage.InventoryUsageId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryUsage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryUsageExists(id))
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

        // POST: api/InventoryUsage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryUsage>> PostInventoryUsage(InventoryUsage inventoryUsage)
        {
            inventoryUsage.InventoryUsageId = new Guid();
            _context.InventoryUsage.Add(inventoryUsage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryUsage", new { id = inventoryUsage.InventoryUsageId }, inventoryUsage);
        }

        // DELETE: api/InventoryUsage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryUsage(Guid id)
        {
            var inventoryUsage = await _context.InventoryUsage.FindAsync(id);
            if (inventoryUsage == null)
            {
                return NotFound();
            }

            _context.InventoryUsage.Remove(inventoryUsage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryUsageExists(Guid id)
        {
            return _context.InventoryUsage.Any(e => e.InventoryUsageId == id);
        }
    }
}
