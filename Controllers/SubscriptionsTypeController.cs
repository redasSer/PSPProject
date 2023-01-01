using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsTypeController : ControllerBase
    {
        private readonly ISubscriptionsTypeService _entityService;

        public SubscriptionsTypeController(ISubscriptionsTypeService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubscriptionsType>> GetSubscriptionsTypes()
        {
            return _entityService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<SubscriptionsType> GetSubscriptionsType(Guid id)
        {
            var entity = _entityService.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult<SubscriptionsType> PutSubscriptionsType(Guid id, SubscriptionsType subscriptionsType)
        {
            try
            {
                _entityService.Update(id, subscriptionsType);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return subscriptionsType;
        }

        [HttpPost]
        public ActionResult<SubscriptionsType> PostSubscriptionsType(SubscriptionsType subscriptionsType)
        {
            _entityService.Create(subscriptionsType);
            return CreatedAtAction("GetSubscriptionsType", subscriptionsType);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscriptionsType(Guid id)
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
