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
    public class PermissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermissionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Permissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
        {
            return await _context.Permissions.ToListAsync();
        }

        // GET: api/Permissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetPermission(Guid id)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
            {
                return NotFound();
            }

            return permission;
        }

        // PUT: api/Permissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermission(Guid id, Permission permission)
        {
            if (id != permission.PermissionId)
            {
                return BadRequest();
            }

            _context.Entry(permission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))
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

        // POST: api/Permissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Permission>> PostPermission(Permission permission)
        {
            permission.PermissionId = new Guid();
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermission", new { id = permission.PermissionId }, permission);
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(Guid id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionExists(Guid id)
        {
            return _context.Permissions.Any(e => e.PermissionId == id);
        }
    }
}
