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
    public class ModifiersController : ControllerBase
    {
        private readonly IModifierService _modifierService;

        public ModifiersController(IModifierService entityService)
        {
            _modifierService = entityService;
        }

        // POST: api/Modifiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Modifier> PostModifier(Modifier modifier)
        {
            try
            {
                _modifierService.Create(modifier);
                return CreatedAtAction("GetModifier", modifier);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Modifiers
        [HttpGet]
        public ActionResult<IEnumerable<Modifier>> GetModifiers()
        {
            return _modifierService.GetAll();
        }

        // GET: api/Modifiers/5
        [HttpGet("{modifierId}")]
        public ActionResult<Modifier> GetModifier(Guid modifierId)
        {
            var modifier = _modifierService.GetById(modifierId);

            if (modifier == null)
            {
                return NotFound();
            }

            return modifier;
        }

        // PUT: api/Modifiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{modifierId}")]
        public ActionResult<Modifier> PutModifier(Guid modifierId, Modifier modifier)
        {
            try
            {
                return _modifierService.Update(modifierId, modifier);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Modifiers/5
        [HttpDelete("{modifierId}")]
        public ActionResult DeleteModifier(Guid modifierId)
        {
            try
            {
                _modifierService.Delete(modifierId);
            }
            catch (SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }
    }
}
