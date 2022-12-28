using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface ICatalogueItemService
    {
        List<CatalogueItem> GetAll();
        CatalogueItem GetById(Guid id);
        CatalogueItem Create(CatalogueItem catalogueItem);
        CatalogueItem Update(Guid id, CatalogueItem catalogueItem);
        void Delete(Guid id);
    }
}
