using PSP.Models;
using System.Collections.Generic;
using System;
using PSP.Enums;

namespace PSP.Interfaces
{
    public interface IOrderService
    {
        /*
        DISCLAIMER:
            Order controller and endpoints are not fully documented.
            There is no way to get orderedItems
            There is no way to get or delete usedDiscountCodes
        */
        Order Create(Order order);
        List<Order> GetAll();
        Order GetById(Guid orderId);
        Order Update(Guid orderId, Order order);
        Order UpdateStatus(Guid orderId, OrderStatus status);
        void Delete(Guid orderId);

        List<OrderedItem> AddItems(Guid orderId, List<OrderedItem> items);
        UsedDiscountCode AddDiscount(Guid orderId, string code, Guid clientId);
        Receipt GetReceipt(Guid orderId);
        void DeleteItem(Guid orderId, Guid orderedItemId);
    }
}
