using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyRewardsController : ControllerBase
    {
        private readonly ILoyaltyRewardsService _loyaltyRewardsService;

        public LoyaltyRewardsController(ILoyaltyRewardsService loyaltyRewardsService)
        {
            _loyaltyRewardsService = loyaltyRewardsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LoyaltyRewards>> GetLoyaltyRewards()
        {
            return _loyaltyRewardsService.GetAll();
        }

        [HttpPost]
        public ActionResult<LoyaltyRewards> PostLoyaltyRewards(LoyaltyRewards loyaltyReward)
        {
            loyaltyReward.LoyaltyRewardId = new Guid();
            _loyaltyRewardsService.Create(loyaltyReward);
            return CreatedAtAction("GetLoyaltyReward", loyaltyReward);
        }

        [HttpGet("client/{clientId}")]
        public ActionResult<IEnumerable<LoyaltyRewards>> GetLoyaltyRewardsByClientId(Guid clientId)
        {
            return _loyaltyRewardsService.GetByClientId(clientId);
        }

        [HttpGet("{loyaltyRewardId}")]
        public ActionResult<LoyaltyRewards> GetLoyaltyReward(Guid loyaltyRewardId)
        {
            var loyaltyReward = _loyaltyRewardsService.GetById(loyaltyRewardId);

            if (loyaltyReward == null)
            {
                return NotFound();
            }

            return loyaltyReward;
        }

        [HttpPut("{loyaltyRewardId}")]
        public ActionResult<LoyaltyRewards> PutLoyaltyReward(Guid loyaltyRewardId, LoyaltyRewards loyaltyReward)
        {
            try
            {
                _loyaltyRewardsService.Update(loyaltyRewardId, loyaltyReward);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return loyaltyReward;
        }

        [HttpDelete("{loyaltyRewardId}")]
        public IActionResult DeleteLoyaltyReward(Guid loyaltyRewardId)
        {
            try
            {
                _loyaltyRewardsService.Delete(loyaltyRewardId);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpPut("{loyaltyRewardId}/status/{status}")]
        public ActionResult<LoyaltyRewards> PutLoyaltyRewardStatus(Guid loyaltyRewardId, LoyaltyRewardsStatus status)
        {
            try
            {
                var loyaltyReward = _loyaltyRewardsService.UpdateLoyaltyRewardsStatus(loyaltyRewardId, status);
                return loyaltyReward;
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
