using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSP.Services
{
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly AppDbContext _context;

        private IQueryable<Subscriptions> Subscriptions => _context.Subscriptions;

        public SubscriptionsService(AppDbContext context)
        {
            _context = context;
        }
        public Subscriptions Create(Subscriptions subscription)
        {
            _context.Add<Subscriptions>(subscription);
            _context.SaveChanges();
            return subscription;
        }

        public void Delete(Guid clientId, Guid typeId)
        {
            var subscription = _context.Find<Subscriptions>(clientId, typeId);
            if (subscription == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Subscriptions.Remove(subscription);
            _context.SaveChanges();
        }

        public List<Subscriptions> GetAll()
        {
            return Subscriptions.ToList();
        }

        public List<Subscriptions> GetByClientId(Guid clientId)
        {
            return Subscriptions.Where(x => x.ClientId == clientId).ToList();
        }

        public Subscriptions GetByClientIdAndTypeId(Guid clientId, Guid typeId)
        {
            return _context.Find<Subscriptions>(clientId, typeId);
        }

        public List<Subscriptions> GetByTypeId(Guid typeId)
        {
            return Subscriptions.Where(x => x.SubscriptionTypeId == typeId).ToList();
        }

        public Subscriptions Update(Guid clientId, Guid typeId, Subscriptions subscription)
        {
            if (typeId != subscription.SubscriptionTypeId || clientId != subscription.ClientId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entityExists(clientId, typeId))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            return subscription;
        }

        private bool entityExists(Guid clientId, Guid typeId)
        {
            return _context.Subscriptions.Any(e => e.SubscriptionTypeId == typeId && e.ClientId == clientId);
        }
    }
}
