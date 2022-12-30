using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Interfaces
{
    public interface ISubscriptionsService
    {
        List<Subscriptions> GetAll();
        Subscriptions Create(Subscriptions subscription);
        List<Subscriptions> GetByClientId(Guid clientId);
        List<Subscriptions> GetByTypeId(Guid typeId);
        Subscriptions GetByClientIdAndTypeId(Guid clientId, Guid typeId);
        Subscriptions Update(Guid clientId, Guid typeId, Subscriptions subscription);
        void Delete(Guid clientId, Guid typeId);

    }
}
