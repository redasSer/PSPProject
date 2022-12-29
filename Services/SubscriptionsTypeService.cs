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
    public class SubscriptionsTypeService : ISubscriptionsTypeService
    {
        private readonly AppDbContext _context;

        private IQueryable<SubscriptionsType> SubscriptionsType => _context.SubscriptionsType;

        public SubscriptionsTypeService(AppDbContext context)
        {
            _context = context;
        }
        public List<SubscriptionsType> GetAll()
        {
            return SubscriptionsType.ToList();
        }

        public SubscriptionsType GetById(Guid id)
        {
            return _context.Find<SubscriptionsType>(id);
        }

        public SubscriptionsType Create(SubscriptionsType subscriptionsType)
        {
            subscriptionsType.SubscriptionTypeId = new Guid();
            _context.Add<SubscriptionsType>(subscriptionsType);
            _context.SaveChanges();
            return subscriptionsType;
        }

        public SubscriptionsType Update(Guid id, SubscriptionsType subscriptionsType)
        {
            if (id != subscriptionsType.SubscriptionTypeId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(subscriptionsType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entityExists(id))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            return subscriptionsType;
        }


        public void Delete(Guid id)
        {
            var subscriptionsType = _context.SubscriptionsType.Find(id);
            if (subscriptionsType == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.SubscriptionsType.Remove(subscriptionsType);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.SubscriptionsType.Any(e => e.SubscriptionTypeId == id);
        }
    }
}
