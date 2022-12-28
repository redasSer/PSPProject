using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface IInventoryUsageService
    {
        List<InventoryUsage> GetAll();
        InventoryUsage GetById(Guid id);
        InventoryUsage Create(InventoryUsage inventoryUsage);
        InventoryUsage Update(Guid id, InventoryUsage inventoryUsage);
        void Delete(Guid id);
    }
}
