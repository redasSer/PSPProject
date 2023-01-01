using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSP.Services
{
    public class LoyaltyRewardsService : ILoyaltyRewardsService
    {
        private readonly AppDbContext _context;
        private IQueryable<LoyaltyRewards> LoyaltyRewards => _context.LoyaltyRewards;

        public LoyaltyRewardsService(AppDbContext context)
        {
            _context = context;
        }

        public LoyaltyRewards Create(LoyaltyRewards loyaltyReward)
        {
            loyaltyReward.LoyaltyRewardId = new Guid();
            _context.Add<LoyaltyRewards>(loyaltyReward);
            _context.SaveChanges();
            return loyaltyReward;
        }

        public void Delete(Guid id)
        {
            var loyaltyReward = _context.LoyaltyRewards.Find(id);
            if (loyaltyReward == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.LoyaltyRewards.Remove(loyaltyReward);
            _context.SaveChanges();
        }

        public List<LoyaltyRewards> GetAll()
        {
            return LoyaltyRewards.ToList();
        }

        public List<LoyaltyRewards> GetByClientId(Guid clientId)
        {
            return LoyaltyRewards.Where(x => x.ClientId == clientId).ToList();
        }

        public LoyaltyRewards GetById(Guid id)
        {
            return _context.Find<LoyaltyRewards>(id);
        }

        public LoyaltyRewards Update(Guid id, LoyaltyRewards loyaltyRewards)
        {
            if (id != loyaltyRewards.LoyaltyRewardId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(loyaltyRewards).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            return loyaltyRewards;
        }

        public LoyaltyRewards UpdateLoyaltyRewardsStatus(Guid id, LoyaltyRewardsStatus status)
        {
            var loyaltyReward = _context.LoyaltyRewards.Find(id);
            if (loyaltyReward == null)
            {
                throw new SqlException("Model does not exists");
            }
            loyaltyReward.Status = status;
            _context.Entry(loyaltyReward).State = EntityState.Modified;
            _context.SaveChanges();
            return loyaltyReward;
        }

        private bool EntityExists(Guid id)
        {
            return _context.LoyaltyRewards.Any(e => e.LoyaltyRewardId == id);
        }
    }
}
