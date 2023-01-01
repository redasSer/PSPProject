using PSP.Enums;
using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Interfaces
{
    public interface ILoyaltyRewardsService
    {
        List<LoyaltyRewards> GetAll();
        LoyaltyRewards Create(LoyaltyRewards loyaltyReward);
        List<LoyaltyRewards> GetByClientId(Guid clientId);
        LoyaltyRewards GetById(Guid id);
        LoyaltyRewards Update(Guid id, LoyaltyRewards loyaltyRewards);
        void Delete(Guid id);
        LoyaltyRewards UpdateLoyaltyRewardsStatus(Guid id, LoyaltyRewardsStatus status);
    }
}
