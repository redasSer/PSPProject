﻿using System;
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
    public class CatalogueItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CatalogueItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CatalogueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogueItem>>> GetCatalogueItems()
        {
            return await _context.CatalogueItems.ToListAsync();
        }

        // GET: api/CatalogueItems/5
        [HttpGet("{catalogueItemId}")]
        public async Task<ActionResult<CatalogueItem>> GetCatalogueItem(Guid catalogueItemId)
        {
            var catalogueItem = await _context.CatalogueItems.FindAsync(catalogueItemId);

            if (catalogueItem == null)
            {
                return NotFound();
            }

            return catalogueItem;
        }

        // PUT: api/CatalogueItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{catalogueItemId}")]
        public async Task<IActionResult> PutCatalogueItem(Guid catalogueItemId, CatalogueItem catalogueItem)
        {
            if (catalogueItemId != catalogueItem.CatalogueItemId)
            {
                return BadRequest();
            }

            _context.Entry(catalogueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogueItemExists(catalogueItemId))
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

        // POST: api/CatalogueItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogueItem>> PostCatalogueItem(CatalogueItem catalogueItem)
        {
            catalogueItem.CatalogueItemId = new Guid();
            _context.CatalogueItems.Add(catalogueItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogueItem", new { catalogueItemId = catalogueItem.CatalogueItemId }, catalogueItem);
        }

        // DELETE: api/CatalogueItems/5
        [HttpDelete("{catalogueItemId}")]
        public async Task<IActionResult> DeleteCatalogueItem(Guid catalogueItemId)
        {
            var catalogueItem = await _context.CatalogueItems.FindAsync(catalogueItemId);
            if (catalogueItem == null)
            {
                return NotFound();
            }

            _context.CatalogueItems.Remove(catalogueItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogueItemExists(Guid catalogueItemId)
        {
            return _context.CatalogueItems.Any(e => e.CatalogueItemId == catalogueItemId);
        }
    }
}
