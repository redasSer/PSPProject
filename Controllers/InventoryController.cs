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
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventory()
        {
            return await _context.Inventory.ToListAsync();
        }

        // GET: api/Inventory/5
        [HttpGet("{inventoryId}")]
        public async Task<ActionResult<Inventory>> GetInventory(Guid inventoryId)
        {
            var inventory = await _context.Inventory.FindAsync(inventoryId);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{inventoryId}")]
        public async Task<IActionResult> PutInventory(Guid inventoryId, Inventory inventory)
        {
            if (inventoryId != inventory.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(inventoryId))
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

        // POST: api/Inventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            inventory.ItemId = new Guid();
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { inventoryId = inventory.ItemId }, inventory);
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{inventoryId}")]
        public async Task<IActionResult> DeleteInventory(Guid inventoryId)
        {
            var inventory = await _context.Inventory.FindAsync(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(Guid inventoryId)
        {
            return _context.Inventory.Any(e => e.ItemId == inventoryId);
        }
    }
}
