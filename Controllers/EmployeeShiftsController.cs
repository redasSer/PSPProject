using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.entity;
using PSP.Models;

namespace PSP.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeShiftsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeShifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeShiftsModel>>> GetEmployeeShifts()
        {
            return EmployeeShiftsModel.Convert(await _context.EmployeeShifts.ToListAsync());
        }

        // GET: api/EmployeeShifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeShiftsModel>> GetEmployeeShift(string id)
        {
            var employeeShift = await _context.EmployeeShifts.FindAsync(id);

            if (employeeShift == null)
            {
                return NotFound();
            }

            return EmployeeShiftsModel.Convert(employeeShift);
        }

        // PUT: api/EmployeeShifts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeShift(string id, EmployeeShiftsModel employeeShiftsModel)
        {
            EmployeeShift employeeShift;
            try
            {
                employeeShift = employeeShiftsModel.Convert();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
            if (id != employeeShift.EmployeeShiftsId.ToString())
            {
                return BadRequest();
            }

            _context.Entry(employeeShift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeShiftExists(id))
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

        // POST: api/EmployeeShifts
        [HttpPost]
        public async Task<ActionResult<EmployeeShiftsModel>> PostEmployeeShift(EmployeeShiftsModel employeeShiftsModel)
        {
            EmployeeShift employeeShift;
            try
            {
                employeeShift = employeeShiftsModel.Convert();

            }
            catch( Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

            _context.EmployeeShifts.Add(employeeShift);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeShiftExists(employeeShift.EmployeeShiftsId.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeShift", new { id = employeeShift.EmployeeShiftsId }, employeeShift);
        }

        // DELETE: api/EmployeeShifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeShift(string id)
        {
            var employeeShift = await _context.EmployeeShifts.FindAsync(id);
            if (employeeShift == null)
            {
                return NotFound();
            }

            _context.EmployeeShifts.Remove(employeeShift);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeShiftExists(string id)
        {
            return _context.EmployeeShifts.Any(e => e.EmployeeShiftsId.ToString() == id);
        }
    }

