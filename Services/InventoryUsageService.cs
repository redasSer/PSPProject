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
    public class InventoryUsageService : IInventoryUsageService
    {
        private readonly AppDbContext _context;
        private IQueryable<InventoryUsage> InventoryUsages => _context.InventoryUsages;

        public InventoryUsageService(AppDbContext context)
        {
            _context = context;
        }

        public List<InventoryUsage> GetAll()
        {
            return InventoryUsages.ToList();
        }

        public InventoryUsage GetById(Guid inventoryUsageId)
        {
            return _context.Find<InventoryUsage>(inventoryUsageId);
        }

        public InventoryUsage Create(InventoryUsage inventoryUsage)
        {
            var newId = new Guid();
            inventoryUsage.InventoryUsageId = newId;
            _context.Add<InventoryUsage>(inventoryUsage);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: CatalogueItemId / ClientId / ItemId do not exist");
            }

            //return inventoryUsage;
            return GetById(newId);
        }

        public InventoryUsage Update(Guid inventoryUsageId, InventoryUsage inventoryUsage)
        {
            if (inventoryUsageId != inventoryUsage.InventoryUsageId)
                throw new SqlException("Id does not match the received model id");

            _context.Entry(inventoryUsage).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(inventoryUsageId))
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
                throw new SqlException("Bad query parameters. Possible reasons: CatalogueItemId / ClientId / ItemId do not exist");
            }

            return GetById(inventoryUsageId);
        }

        public void Delete(Guid inventoryUsageId)
        {
            var inventoryUsage = _context.InventoryUsages.Find(inventoryUsageId);
            if (inventoryUsage == null)
                throw new SqlException("Entity does not exists");

            _context.InventoryUsages.Remove(inventoryUsage);
            _context.SaveChanges();

            if (_context.Find<InventoryUsage>(inventoryUsageId) != null)
                throw new SqlException("Failed to delete entity");
        }

        private bool EntityExists(Guid inventoryUsageId)
        {
            return _context.InventoryUsages.Any(e => e.InventoryUsageId == inventoryUsageId);
        }
    }
}
