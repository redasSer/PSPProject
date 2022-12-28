using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueItemsController : ControllerBase
    {
        private readonly ICatalogueItemService _catalogueItemService;

        public CatalogueItemsController(ICatalogueItemService entityService)
        {
            _catalogueItemService = entityService;
        }

        // POST: api/CatalogueItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CatalogueItem> PostCatalogueItem(CatalogueItem catalogueItem)
        {
            try
            {
                _catalogueItemService.Create(catalogueItem);
                return CreatedAtAction("GetCatalogueItem", catalogueItem);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/CatalogueItems
        [HttpGet]
        public ActionResult<IEnumerable<CatalogueItem>> GetCatalogueItems()
        {
            return _catalogueItemService.GetAll();
        }

        // GET: api/CatalogueItems/5
        [HttpGet("{catalogueItemId}")]
        public ActionResult<CatalogueItem> GetCatalogueItem(Guid catalogueItemId)
        {
            var catalogueItem = _catalogueItemService.GetById(catalogueItemId);

            if (catalogueItem == null)
            {
                return NotFound();
            }

            return catalogueItem;
        }

        // PUT: api/CatalogueItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{catalogueItemId}")]
        public ActionResult<CatalogueItem> PutCatalogueItem(Guid catalogueItemId, CatalogueItem catalogueItem)
        {
            try
            {
                return _catalogueItemService.Update(catalogueItemId, catalogueItem);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/CatalogueItems/5
        [HttpDelete("{catalogueItemId}")]
        public ActionResult DeleteCatalogueItem(Guid catalogueItemId)
        {
            try
            {
                _catalogueItemService.Delete(catalogueItemId);
            }
            catch(SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }
    }
}
