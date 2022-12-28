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
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private IQueryable<Order> Orders => _context.Orders;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            var newId = new Guid();
            order.OrderId = newId;
            _context.Add<Order>(order);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: CustomerId / EmployeeId do not exist");
            }

            //return order;
            return GetById(newId);
        }

        public List<Order> GetAll()
        {
            return Orders.ToList();
        }

        public Order GetById(Guid orderId)
        {
            return _context.Find<Order>(orderId);
        }

        public Order Update(Guid orderId, Order order)
        {
            if (orderId != order.OrderId)
                throw new SqlException("Id does not match the received model id");

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(orderId))
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
                throw new SqlException("Bad query parameters. Possible reasons: CustomerId / EmployeeId do not exist");
            }

            return GetById(orderId);
        }

        public Order UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = _context.Find<Order>(orderId);
            if (order == null)
                throw new SqlException("Order not found");

            order.Status = status;
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(orderId))
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
                throw new SqlException("Bad query parameters. Possible reasons: CustomerId / EmployeeId do not exist");
            }

            return GetById(orderId);
        }

        public void Delete(Guid orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
                throw new SqlException("Entity does not exists");

            _context.Orders.Remove(order);
            _context.SaveChanges();

            if (_context.Find<Order>(orderId) != null)
                throw new SqlException("Failed to delete entity");
        }

        public List<OrderedItem> AddItems(Guid orderId, List<OrderedItem> items)
        {
            var len = items.Count;
            var addedItems = new List<OrderedItem>();
            for (int i = 0; i < len; ++i)
            {
                if(!items[i].OrderId.Equals(orderId))
                    throw new SqlException("orderId does not match the " + i + " received model orderId");
            }
            for (int i = 0; i < len; ++i)
            {
                var newId = new Guid();
                items[i].OrderedItemId = newId;
                _context.Add<OrderedItem>(items[i]);

                try
                {
                    _context.SaveChanges();
                    addedItems.Add(items[i]);
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    // Remove successfuly added items
                    foreach(var item in addedItems)
                    {
                        _context.Remove<OrderedItem>(item);
                        _context.SaveChanges();
                    }
                    throw new SqlException("Bad query parameters. Possible reasons: " + i + " entities LocationId / OrderId / CatalogueItemId does not exist");
                }
            }

            return addedItems;
        }

        public UsedDiscountCode AddDiscount(Guid orderId, string code, Guid clientId)
        {
            UsedDiscountCode usedCode = new UsedDiscountCode(){ OrderId=orderId, Code=code, ClientId=clientId };
            _context.Add<UsedDiscountCode>(usedCode);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: CustomerId / EmployeeId do not exist");
            }

            return usedCode;
        }

        public Receipt GetReceipt(Guid orderId)
        {
            var receipt = new Receipt();
            var order = _context.Orders.Find(orderId);
            if (order == null)
                throw new SqlException("Entity does not exists");

            var clientId = _context.Find<Customer>(order.CustomerId).clientId;
            
            var items = _context.OrderedItems.Where(orderedItem => orderedItem.OrderId == orderId).ToList();
            if (items.Count <= 0)
                throw new SqlException("Order is empty");

            var total = TotalPrice(items);

            receipt.ClientId = clientId;
            receipt.Order = order;
            receipt.OrderedItems = items;
            receipt.Total = total;

            return receipt;
        }

        public void DeleteItem(Guid orderId, Guid orderedItemId)
        {
            var item = _context.Find<OrderedItem>(orderedItemId);
            if (item == null)
                throw new SqlException("Entity does not exists");
            if (!item.OrderId.Equals(orderId))
                throw new SqlException("Entity not part of order");

            _context.Remove(item);
            _context.SaveChanges();

            if (_context.Find<OrderedItem>(orderedItemId) != null)
                throw new SqlException("Failed to delete entity");
        }

        private bool EntityExists(Guid orderId)
        {
            return _context.Orders.Any(e => e.OrderId == orderId);
        }

        private double TotalPrice(List<OrderedItem> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.Price * (1 + item.Tax);
            }
            return total;
        }
    }
}
