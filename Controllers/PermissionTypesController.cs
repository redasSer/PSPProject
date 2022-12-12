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
    public class PermissionTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PermissionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionType>>> GetPermissionTypes()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        // GET: api/PermissionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionType>> GetPermissionType(Guid id)
        {
            var permissionType = await _context.PermissionTypes.FindAsync(id);

            if (permissionType == null)
            {
                return NotFound();
            }

            return permissionType;
        }

        // PUT: api/PermissionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionType(Guid id, PermissionType permissionType)
        {
            if (id != permissionType.PermissionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(permissionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionTypeExists(id))
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

        // POST: api/PermissionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PermissionType>> PostPermissionType(PermissionType permissionType)
        {
            permissionType.PermissionTypeId = new Guid();
            _context.PermissionTypes.Add(permissionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermissionType", new { id = permissionType.PermissionTypeId }, permissionType);
        }

        // DELETE: api/PermissionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionType(Guid id)
        {
            var permissionType = await _context.PermissionTypes.FindAsync(id);
            if (permissionType == null)
            {
                return NotFound();
            }

            _context.PermissionTypes.Remove(permissionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionTypeExists(Guid id)
        {
            return _context.PermissionTypes.Any(e => e.PermissionTypeId == id);
        }
    }
}
