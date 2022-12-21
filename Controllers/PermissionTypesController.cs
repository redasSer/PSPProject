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
    public class PermissionTypesController : ControllerBase
    {
        private readonly IPermissionTypeService _entityService;

        public PermissionTypesController(IPermissionTypeService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/PermissionTypes
        [HttpGet]
        public ActionResult<IEnumerable<PermissionType>> GetPermissionTypes()
        {
            return _entityService.GetAll();
        }

        // GET: api/PermissionTypes/5
        [HttpGet("{id}")]
        public ActionResult<PermissionType> GetPermissionType(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/PermissionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<PermissionType> PutPermissionType(Guid id, PermissionType permissionType)
        {
            try
            {
                _entityService.Update(id, permissionType);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return permissionType;
        }

        // POST: api/PermissionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<PermissionType> PostPermissionType(PermissionType permissionType)
        {
            _entityService.Create(permissionType);
            return CreatedAtAction("GetPermissionType", permissionType);
        }

        // DELETE: api/PermissionTypes/5
        [HttpDelete("{id}")]
        public IActionResult DeletePermissionType(Guid id)
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
