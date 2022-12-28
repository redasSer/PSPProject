using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService entityService)
        {
            _orderService = entityService;
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                _orderService.Create(order);
                return CreatedAtAction("GetOrder", order);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _orderService.GetAll();
        }

        // GET: api/Orders/5
        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrder(Guid orderId)
        {
            var order = _orderService.GetById(orderId);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{orderId}")]
        public ActionResult<Order> PutOrder(Guid orderId, Order order)
        {
            try
            {
                return _orderService.Update(orderId, order);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Orders/5/status/statusEnum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{orderId}/status/{status}")]
        public ActionResult<Order> PutOrder(Guid orderId, OrderStatus status)
        {
            try
            {
                return _orderService.UpdateStatus(orderId, status);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{orderId}")]
        public ActionResult DeleteOrder(Guid orderId)
        {
            try
            {
                _orderService.Delete(orderId);
            }
            catch (SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Orders/5/items
        [HttpPost("{orderId}/items")]
        public ActionResult<IEnumerable<OrderedItem>> AddItemsToOrder(Guid orderId, List<OrderedItem> items)
        {
            try
            {
                return _orderService.AddItems(orderId, items);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Orders/5/discount/8
        [HttpPost("{orderId}/discount/{code}/{clientId}")]
        public ActionResult<UsedDiscountCode> AddDiscountToOrder(Guid orderId, string code, Guid clientId)
        {
            try
            {
                return _orderService.AddDiscount(orderId, code, clientId);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orders/5/receipt
        [HttpGet("{orderId}/receipt")]
        public ActionResult<Receipt> GetReceipt(Guid orderId)
        {
            try
            {
                return _orderService.GetReceipt(orderId);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Orders/5/items/7
        [HttpDelete("{orderId}/items/{orderedItemId}")]
        public ActionResult DeleteOrderedItem(Guid orderId, Guid orderedItemId)
        {
            try
            {
                _orderService.DeleteItem(orderId, orderedItemId);
            }
            catch (SqlException ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }

            return NoContent();
        }
    }
}
