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
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _entityService;

        public PermissionsController(IPermissionService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/Permissions
        [HttpGet]
        public ActionResult<IEnumerable<Permission>> GetPermissions()
        {
            return _entityService.GetAll();
        }

        // GET: api/Permissions/5
        [HttpGet("{id}")]
        public ActionResult<Permission> GetPermission(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Permissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Permission> PutPermission(Guid id, Permission permission)
        {
            try
            {
                _entityService.Update(id, permission);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return permission;
        }

        // POST: api/Permissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Permission> PostPermission(Permission permission)
        {
            try
            {
                _entityService.Create(permission);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction("GetPermission", permission);
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{id}")]
        public IActionResult DeletePermission(Guid id)
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
