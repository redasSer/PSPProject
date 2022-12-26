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
    public class InventoryUsagesController : ControllerBase
    {
        private readonly IInventoryUsageService _inventoryUsageService;

        public InventoryUsagesController(IInventoryUsageService entityService)
        {
            _inventoryUsageService = entityService;
        }

        // POST: api/InventoryUsages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<InventoryUsage> PostInventoryUsage(InventoryUsage inventoryUsage)
        {
            try
            {
                _inventoryUsageService.Create(inventoryUsage);
                return CreatedAtAction("GetInventoryUsage", inventoryUsage);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/InventoryUsages
        [HttpGet]
        public ActionResult<IEnumerable<InventoryUsage>> GetInventoryUsages()
        {
            return _inventoryUsageService.GetAll();
        }

        // GET: api/InventoryUsages/5
        [HttpGet("{inventoryUsageId}")]
        public ActionResult<InventoryUsage> GetInventoryUsage(Guid inventoryUsageId)
        {
            var inventoryUsage = _inventoryUsageService.GetById(inventoryUsageId);

            if (inventoryUsage == null)
            {
                return NotFound();
            }

            return inventoryUsage;
        }

        // PUT: api/InventoryUsages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{inventoryUsageId}")]
        public ActionResult<InventoryUsage> PutInventoryUsage(Guid inventoryUsageId, InventoryUsage inventoryUsage)
        {
            try
            {
                return _inventoryUsageService.Update(inventoryUsageId, inventoryUsage);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/InventoryUsages/5
        [HttpDelete("{inventoryUsageId}")]
        public ActionResult DeleteInventoryUsage(Guid inventoryUsageId)
        {
            try
            {
                _inventoryUsageService.Delete(inventoryUsageId);
            }
            catch (SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }
    }
}
