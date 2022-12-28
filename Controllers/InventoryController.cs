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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService entityService)
        {
            _inventoryService = entityService;
        }

        // POST: api/Inventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Inventory> PostInventory(Inventory inventory)
        {
            try
            {
                _inventoryService.Create(inventory);
                return CreatedAtAction("GetInventory", inventory);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Inventory
        [HttpGet]
        public ActionResult<IEnumerable<Inventory>> GetInventory()
        {
            return _inventoryService.GetAll();
        }

        // GET: api/Inventory/5
        [HttpGet("{itemId}")]
        public ActionResult<Inventory> GetInventory(Guid itemId)
        {
            var inventory = _inventoryService.GetById(itemId);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{itemId}")]
        public ActionResult<Inventory> PutInventory(Guid itemId, Inventory inventory)
        {
            try
            {
                return _inventoryService.Update(itemId, inventory);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{inventoryId}")]
        public ActionResult DeleteInventory(Guid itemId)
        {
            try
            {
                _inventoryService.Delete(itemId);
            }
            catch(SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }
    }
}
