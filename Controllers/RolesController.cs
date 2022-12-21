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
using PSP.Services;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _entityService;

        public RolesController(IRoleService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/Roles
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            return _entityService.GetAll();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public ActionResult<Role> GetRole(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Role> PutRole(Guid id, Role Role)
        {
            try
            {
                _entityService.Update(id, Role);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return Role;
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Role> PostRole(Role role)
        {
            try
            {
                _entityService.Create(role);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction("GetRole", role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(Guid id)
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
