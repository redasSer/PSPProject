using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface IOrderedItemModificationService
    {
        List<OrderedItemModification> GetAll();
        List<OrderedItemModification> GetById(Guid orderedItemId);
        OrderedItemModification Create(OrderedItemModification orderedItemModification);
        void Delete(Guid orderedItemId, Guid modifierId);
    }
}
