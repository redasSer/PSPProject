using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Data;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Services
{
    public class OrderedItemModificationService : IOrderedItemModificationService
    {
        private readonly AppDbContext _context;
        private IQueryable<OrderedItemModification> OrderedItemModifications => _context.OrderedItemModifications;

        public OrderedItemModificationService(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderedItemModification> GetAll()
        {
            return OrderedItemModifications.ToList();
        }

        public List<OrderedItemModification> GetById(Guid orderedItemId)
        {
            return _context.OrderedItemModifications.Where(item => item.OrderedItemId.Equals(orderedItemId)).ToList();
        }

        public OrderedItemModification Create(OrderedItemModification orderedItemModification)
        {
            _context.Add<OrderedItemModification>(orderedItemModification);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: OrderedItemId / ModifierId do not exist");
            }

            //return orderedItemModification;
            return _context.Find<OrderedItemModification>(orderedItemModification.OrderedItemId, orderedItemModification.ModifierId);
        }

        public void Delete(Guid orderedItemId, Guid modifierId)
        {
            var orderedItemModification = _context.OrderedItemModifications.Find(orderedItemId, modifierId);
            if (orderedItemModification == null)
                throw new SqlException("Entity does not exists");

            _context.OrderedItemModifications.Remove(orderedItemModification);
            _context.SaveChanges();

            if (_context.Find<OrderedItemModification>(orderedItemId, modifierId) != null)
                throw new SqlException("Failed to delete entity");
        }
    }
}
