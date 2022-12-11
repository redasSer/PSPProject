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
    public class EmployeeCardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeCard>>> GetEmployeeCards()
        {
            return await _context.EmployeeCards.ToListAsync();
        }

        // GET: api/EmployeeCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeCard>> GetEmployeeCard(Guid id)
        {
            var employeeCard = await _context.EmployeeCards.FindAsync(id);

            if (employeeCard == null)
            {
                return NotFound();
            }

            return employeeCard;
        }

        // PUT: api/EmployeeCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeCard(Guid id, EmployeeCard employeeCard)
        {
            if (id != employeeCard.EmployeeCardId)
            {
                return BadRequest();
            }
            if (employeeCard.Status > Enum.GetValues(typeof(Enums.CardStatus)).Cast<Enums.CardStatus>().Last()) return BadRequest("Bad status enum");

            _context.Entry(employeeCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeCardExists(id))
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
        [HttpPut("{id}/Stutus/{status}")]
        public async Task<IActionResult> PutEmployeeCardStatus(Guid id,int status)
        {

            var employeeCard = await _context.EmployeeCards.FindAsync(id);
            if (employeeCard == null) return BadRequest("EmployeeCard doesn't exist");
            if (status > (int)Enum.GetValues(typeof(Enums.CardStatus)).Cast<Enums.CardStatus>().Last()) return BadRequest("Bad status enum");

            employeeCard.Status =  (Enums.CardStatus)status;

            _context.Entry(employeeCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeCardExists(id))
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
        // POST: api/EmployeeCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeCard>> PostEmployeeCard(EmployeeCard employeeCard)
        {
            employeeCard.EmployeeCardId = new Guid();
            if (employeeCard.Status > Enum.GetValues(typeof(Enums.CardStatus)).Cast<Enums.CardStatus>().Last()) return BadRequest("Bad status enum");
            _context.EmployeeCards.Add(employeeCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeCard", new { id = employeeCard.EmployeeCardId }, employeeCard);
        }

        // DELETE: api/EmployeeCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeCard(Guid id)
        {
            var employeeCard = await _context.EmployeeCards.FindAsync(id);
            if (employeeCard == null)
            {
                return NotFound();
            }

            _context.EmployeeCards.Remove(employeeCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeCardExists(Guid id)
        {
            return _context.EmployeeCards.Any(e => e.EmployeeCardId == id);
        }
    }
}
