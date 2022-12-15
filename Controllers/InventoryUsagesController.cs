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
    public class InventoryUsagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryUsagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InventoryUsages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryUsage>>> GetInventoryUsages()
        {
            return await _context.InventoryUsages.ToListAsync();
        }

        // GET: api/InventoryUsages/5
        [HttpGet("{inventoryUsageId}")]
        public async Task<ActionResult<InventoryUsage>> GetInventoryUsage(Guid inventoryUsageId)
        {
            var inventoryUsage = await _context.InventoryUsages.FindAsync(inventoryUsageId);

            if (inventoryUsage == null)
            {
                return NotFound();
            }

            return inventoryUsage;
        }

        // PUT: api/InventoryUsages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{inventoryUsageId}")]
        public async Task<IActionResult> PutInventoryUsage(Guid inventoryUsageId, InventoryUsage inventoryUsage)
        {
            if (inventoryUsageId != inventoryUsage.InventoryUsageId)
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
                if (!InventoryUsageExists(inventoryUsageId))
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

        // POST: api/InventoryUsages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryUsage>> PostInventoryUsage(InventoryUsage inventoryUsage)
        {
            inventoryUsage.InventoryUsageId = new Guid();
            _context.InventoryUsages.Add(inventoryUsage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryUsage", new { inventoryUsageId = inventoryUsage.InventoryUsageId }, inventoryUsage);
        }

        // DELETE: api/InventoryUsages/5
        [HttpDelete("{inventoryUsageId}")]
        public async Task<IActionResult> DeleteInventoryUsage(Guid inventoryUsageId)
        {
            var inventoryUsage = await _context.InventoryUsages.FindAsync(inventoryUsageId);
            if (inventoryUsage == null)
            {
                return NotFound();
            }

            _context.InventoryUsages.Remove(inventoryUsage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryUsageExists(Guid inventoryUsageId)
        {
            return _context.InventoryUsages.Any(e => e.InventoryUsageId == inventoryUsageId);
        }
    }
}
