using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _entityService;

        public LocationsController(ILocationService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/Locations
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            return _entityService.GetAll();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public ActionResult<Location> GetLocation(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Location> PutLocation(Guid id, Location location)
        {
            try
            {
                _entityService.Update(id, location);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return location;
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Location> PostLocation(Location location)
        {
            try
            {
                _entityService.Create(location);
                return CreatedAtAction("GetLocation", location);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(Guid id)
        {
            try
            {
                _entityService.Delete(id);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}
