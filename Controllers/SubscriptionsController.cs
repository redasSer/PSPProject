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
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsService _entityService;

        public SubscriptionsController(ISubscriptionsService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subscriptions>> GetSubscriptions()
        {
            return _entityService.GetAll();
        }

        [HttpPost]
        public ActionResult<Subscriptions> PostSubscriptions(Subscriptions subscription)
        {
            _entityService.Create(subscription);
            return CreatedAtAction("GetSubscriptions", subscription);
        }

        [HttpGet("client/{clientId}")]
        public ActionResult<IEnumerable<Subscriptions>> GetSubscriptionsByClientId(Guid clientId)
        {
            return _entityService.GetByClientId(clientId);
        }

        [HttpGet("type/{typeId}")]
        public ActionResult<IEnumerable<Subscriptions>> GetSubscriptionsByTypeId(Guid typeId)
        {
            return _entityService.GetByTypeId(typeId);
        }

        [HttpGet("client/{clientId}/type/{typeId}")]
        public ActionResult<Subscriptions> GetSubscriptionByClientIdAndTypeId(Guid clientId, Guid typeId)
        {
            var entity = _entityService.GetByClientIdAndTypeId(clientId, typeId);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPut("client/{clientId}/type/{typeId}")]
        public ActionResult<Subscriptions> PutSubscription(Guid clientId, Guid typeId, Subscriptions subscription)
        {
            try
            {
                _entityService.Update(clientId, typeId, subscription);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return subscription;
        }

        [HttpDelete("client/{clientId}/type/{typeId}")]
        public IActionResult DeleteSubscription(Guid clientId, Guid typeId)
        {
            try
            {
                _entityService.Delete(clientId, typeId);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

    }
}
