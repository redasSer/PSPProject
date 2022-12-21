using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedItemModificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderedItemModificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderedItemModifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderedItemModification>>> GetOrderedItemModifications()
        {
            return await _context.OrderedItemModifications.ToListAsync();
        }

        // GET: api/OrderedItemModifications/5
        [HttpGet("{orderedItemId}")]
        public async Task<ActionResult<IEnumerable<OrderedItemModification>>> GetOrderedItemModification(Guid orderedItemId)
        {
            var orderedItemModifications = await _context.OrderedItemModifications.Where(item => item.OrderedItemId.Equals(orderedItemId)).ToListAsync();

            if (orderedItemModifications == null)
            {
                return NotFound();
            }

            return orderedItemModifications;
        }

        // POST: api/OrderedItemModifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderedItemModification>> PostOrderedItemModification(OrderedItemModification orderedItemModifications)
        {
            _context.OrderedItemModifications.Add(orderedItemModifications);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderedItemModification", new { id = orderedItemModifications.OrderedItemId }, orderedItemModifications);
        }

        // DELETE: api/OrderedItemModifications/5
        [HttpDelete("{modifierId}")]
        public async Task<IActionResult> DeleteOrderedItemModification(Guid modifierId)
        {
            var orderedItemModification = await _context.OrderedItemModifications.Where(item => item.ModifierId.Equals(modifierId)).FirstOrDefaultAsync();
            if (orderedItemModification == null)
            {
                return NotFound();
            }

            _context.OrderedItemModifications.Remove(orderedItemModification);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
