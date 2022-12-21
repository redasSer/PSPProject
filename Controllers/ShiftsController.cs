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
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _entityService;

        public ShiftsController(IShiftService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/Shifts
        [HttpGet]
        public ActionResult<IEnumerable<Shift>> GetShifts()
        {
            return _entityService.GetAll();
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public ActionResult<Shift> GetShift(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Shifts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Shift> PutShift(Guid id, Shift shift)
        {
            try
            {
                _entityService.Update(id, shift);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return shift;
        }

        // POST: api/Shifts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Shift> PostShift(Shift shift)
        {
            _entityService.Create(shift);
            return CreatedAtAction("GetShift", shift);
        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteShift(Guid id)
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
