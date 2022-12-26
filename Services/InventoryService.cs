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
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;
        private IQueryable<Inventory> Inventory => _context.Inventory;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Inventory> GetAll()
        {
            return Inventory.ToList();
        }

        public Inventory GetById(Guid itemId)
        {
            return _context.Find<Inventory>(itemId);
        }

        public Inventory Create(Inventory inventory)
        {
            var newId = new Guid();
            inventory.ItemId = newId;
            _context.Add<Inventory>(inventory);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: LocationId does not exist");
            }

            //return inventory;
            return GetById(newId);
        }

        public Inventory Update(Guid itemId, Inventory inventory)
        {
            if (itemId != inventory.ItemId)
                throw new SqlException("id does not match the received model id");

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(itemId))
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
                throw new SqlException("Bad query body. Possible reasons: LocationId does not exist");
            }

            return GetById(itemId);
        }

        public void Delete(Guid itemId)
        {
            var inventory = _context.Inventory.Find(itemId);
            if (inventory == null)
                throw new SqlException("Entity does not exists");

            _context.Inventory.Remove(inventory);
            _context.SaveChanges();

            if (_context.Find<Inventory>(itemId) != null)
                throw new SqlException("Failed to delete entity");
        }

        private bool EntityExists(Guid itemId)
        {
            return _context.Inventory.Any(e => e.ItemId == itemId);
        }
    }
}
