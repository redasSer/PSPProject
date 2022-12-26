using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedItemModificationsController : ControllerBase
    {
        private readonly IOrderedItemModificationService _orderedItemModificationService;

        public OrderedItemModificationsController(IOrderedItemModificationService entityService)
        {
            _orderedItemModificationService = entityService;
        }

        // POST: api/OrderedItemModifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<OrderedItemModification> PostOrderedItemModification(OrderedItemModification orderedItemModifications)
        {
            try
            {
                _orderedItemModificationService.Create(orderedItemModifications);
                return CreatedAtAction("GetCatalogueItem", orderedItemModifications);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/OrderedItemModifications
        [HttpGet]
        public ActionResult<IEnumerable<OrderedItemModification>> GetOrderedItemModifications()
        {
            return _orderedItemModificationService.GetAll();
        }

        // GET: api/OrderedItemModifications/5
        [HttpGet("{orderedItemId}")]
        public ActionResult<IEnumerable<OrderedItemModification>> GetOrderedItemModification(Guid orderedItemId)
        {
            var orderedItemModifications = _orderedItemModificationService.GetById(orderedItemId);

            if (orderedItemModifications == null)
            {
                return NotFound();
            }

            return orderedItemModifications;
        }

        // DELETE: api/OrderedItemModifications/5/modifier/7
        [HttpDelete("{orderedItemId}/modifier/{modifierId}")]
        public ActionResult DeleteOrderedItemModification(Guid orderedItemIt, Guid modifierId)
        {
            try
            {
                _orderedItemModificationService.Delete(orderedItemIt, modifierId);
            }
            catch (SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }
    }
}
