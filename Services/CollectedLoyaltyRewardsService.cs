using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Controllers;
using PSP.Data;
using PSP.Models;

namespace PSP.Services;

public class CollectedLoyaltyRewardsService : ICollectedLoyaltyRewardsService
{
    private readonly AppDbContext _db;

    public CollectedLoyaltyRewardsService(AppDbContext db)
    {
        _db = db;
    }
    
    private IQueryable<CollectedLoyaltyReward> CollectedLoyaltyRewards => _db.CollectedLoyaltyRewards;

    public List<CollectedLoyaltyReward> GetAll()
    {
        return CollectedLoyaltyRewards.ToList();
    }

    public CollectedLoyaltyReward GetById(Guid guid)
    {
        return _db.CollectedLoyaltyRewards.Find(guid);
    }

    public CollectedLoyaltyReward Create(CollectedLoyaltyReward collectedLoyaltyReward)
    {
        CollectedLoyaltyReward newCollectedLoyaltyReward = new CollectedLoyaltyReward();

        newCollectedLoyaltyReward.orderId = collectedLoyaltyReward.orderId;
        newCollectedLoyaltyReward.loyaltyRewardId = collectedLoyaltyReward.loyaltyRewardId;
        
        _db.CollectedLoyaltyRewards.Add(newCollectedLoyaltyReward);
        _db.SaveChanges();
        
        return newCollectedLoyaltyReward;
    }

    public void Delete(Guid orderid, Guid rewardid)
    {
        CollectedLoyaltyReward collectedLoyaltyReward = _db.CollectedLoyaltyRewards.Find(orderid, rewardid);
        _db.CollectedLoyaltyRewards.Remove(collectedLoyaltyReward);
        _db.SaveChanges();
    }

}