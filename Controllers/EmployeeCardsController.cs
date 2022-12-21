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
    public class EmployeeCardsController : ControllerBase
    {
        private readonly IEmployeeCardService _entityService;

        public EmployeeCardsController(IEmployeeCardService entityService)
        {
            _entityService = entityService;
        }

        // GET: api/EmployeeCards
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeCard>> GetEmployeeCards()
        {
            return _entityService.GetAll();
        }

        // GET: api/EmployeeCards/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeCard> GetEmployeeCard(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/EmployeeCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<EmployeeCard> PutEmployeeCard(Guid id, EmployeeCard employeeCard)
        {
            try
            {
                _entityService.Update(id, employeeCard);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return employeeCard;
        }

        // POST: api/EmployeeCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<EmployeeCard> PostEmployeeCard(EmployeeCard employeeCard)
        {
            try
            {
                _entityService.Create(employeeCard);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction("GetEmployeeCard", employeeCard);
        }

        // DELETE: api/EmployeeCards/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeCard(Guid id)
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

        [HttpPut("{id}/status/{status}")]
        public ActionResult<EmployeeCard> PutEmployeeCardStatus(Guid id,int status)
        {
            try
            {
                return _entityService.UpdateStatus(id, status);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
