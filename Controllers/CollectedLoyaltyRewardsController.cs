using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PSP.Models;
using PSP.Services;

namespace PSP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollectedLoyaltyRewardsController
{
    private readonly ICollectedLoyaltyRewardsService _collectedLoyaltyRewardsService;
    
    public CollectedLoyaltyRewardsController(ICollectedLoyaltyRewardsService collectedLoyaltyRewardsService)
    {
        _collectedLoyaltyRewardsService = collectedLoyaltyRewardsService;
    }

    [HttpGet]
    public List<CollectedLoyaltyReward> GetAll()
    {
        return _collectedLoyaltyRewardsService.GetAll().ToList();
    }
    
    [HttpGet("{id:guid}")]
    public CollectedLoyaltyReward GetById(Guid id)
    {
        return _collectedLoyaltyRewardsService.GetById(id);
    }
    
    [HttpPost]
    public CollectedLoyaltyReward Create(CollectedLoyaltyReward collectedLoyaltyReward)
    {
        return _collectedLoyaltyRewardsService.Create(collectedLoyaltyReward);
    }
    
    [HttpDelete("/order/{orderid:guid}/reward/{rewardid:guid}")]
    public void Delete(Guid orderid, Guid rewardid)
    {
        _collectedLoyaltyRewardsService.Delete(orderid, rewardid);
    }
}