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
    public class EmployeeShiftsController : ControllerBase
    {
        private readonly IEmployeeShiftService _entityService;

        public EmployeeShiftsController(IEmployeeShiftService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/EmployeeShifts
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeShiftsModel>> GetEmployeeShifts()
        {
            return EmployeeShiftsModel.Convert(_entityService.GetAll());
        }

        // GET: api/EmployeeShifts/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeShiftsModel> GetEmployeeShift(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return EmployeeShiftsModel.Convert(entity); ;
        }

        // PUT: api/EmployeeShifts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<EmployeeShiftsModel> PutEmployeeShift(Guid id, EmployeeShiftsModel employeeShiftmodel)
        {
            try
            {
                EmployeeShift employeeShift = employeeShiftmodel.Convert();
                _entityService.Update(id, employeeShift);
                return EmployeeShiftsModel.Convert(employeeShift);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/EmployeeShifts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<EmployeeShiftsModel> PostEmployeeShift(EmployeeShiftsModel employeeShiftsModel)
        {
            employeeShiftsModel.EmployeeShiftsId = new Guid();
            EmployeeShift employeeShift;
            try
            {
                employeeShift = employeeShiftsModel.Convert();
                _entityService.Create(employeeShift);
                return CreatedAtAction("GetEmployeeShift", employeeShiftsModel);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/EmployeeShifts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeShift(Guid id)
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
