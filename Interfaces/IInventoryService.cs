using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface IInventoryService
    {
        List<Inventory> GetAll();
        Inventory GetById(Guid id);
        Inventory Create(Inventory inventory);
        Inventory Update(Guid id, Inventory inventory);
        void Delete(Guid id);
    }
}
