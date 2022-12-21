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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _entityService;

        public EmployeesController(IEmployeeService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return _entityService.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Employee> PutEmployee(Guid id, Employee employee)
        {
            try
            {
                _entityService.Update(id, employee);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return employee;
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
            try
            {
                _entityService.Create(employee);
                return CreatedAtAction("GetEmployee", employee);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
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
