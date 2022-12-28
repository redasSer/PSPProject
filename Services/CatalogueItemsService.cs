using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Services
{
    public class CatalogueItemsService : ICatalogueItemService
    {
        private readonly AppDbContext _context;
        private IQueryable<CatalogueItem> CatalogueItems => _context.CatalogueItems;

        public CatalogueItemsService(AppDbContext context)
        {
            _context = context;
        }

        public List<CatalogueItem> GetAll()
        {
            return CatalogueItems.ToList();
        }

        public CatalogueItem GetById(Guid catalogueItemId)
        {
            return _context.Find<CatalogueItem>(catalogueItemId);
        }

        public CatalogueItem Create(CatalogueItem catalogueItem)
        {
            var newId = new Guid();
            catalogueItem.CatalogueItemId = newId;
            //catalogueItem.CatalogueItemId = new Guid();
            _context.Add<CatalogueItem>(catalogueItem);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: ClientId does not exist");
            }

            //return catalogueItem;
            return GetById(newId);
        }

        public CatalogueItem Update(Guid catalogueItemId, CatalogueItem catalogueItem)
        {
            if (catalogueItemId != catalogueItem.CatalogueItemId)
                throw new SqlException("id does not match the received model id");

            _context.Entry(catalogueItem).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(catalogueItemId))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            catch (DbUpdateException)
            {
                throw new SqlException("Bad query body. Possible reasons: ClientId does not exist");
            }

            return GetById(catalogueItemId);
        }

        public void Delete(Guid catalogueItemId)
        {
            var catalogueItem = _context.CatalogueItems.Find(catalogueItemId);
            if (catalogueItem == null)
                throw new SqlException("Entity does not exists");

            _context.CatalogueItems.Remove(catalogueItem);
            _context.SaveChanges();

            if (_context.Find<CatalogueItem>(catalogueItemId) != null)
                throw new SqlException("Failed to delete entity");
        }

        private bool EntityExists(Guid catalogueItemId)
        {
            return _context.CatalogueItems.Any(e => e.CatalogueItemId == catalogueItemId);
        }
    }
}
