using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Interfaces
{
    public interface ISubscriptionsTypeService
    {
        List<SubscriptionsType> GetAll();
        SubscriptionsType GetById(Guid id);
        SubscriptionsType Create(SubscriptionsType subscriptionsType);
        SubscriptionsType Update(Guid id, SubscriptionsType subscriptionsType);
        void Delete(Guid id);
    }
}
