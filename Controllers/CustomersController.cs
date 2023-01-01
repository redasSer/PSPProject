using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _customersService.GetAll();
        }

        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            customer.customerId = new Guid();
            _customersService.Create(customer);
            return CreatedAtAction("GetCustomer",
                                   customer);
        }

        [HttpGet("client/{clientId}")]
        public ActionResult<IEnumerable<Customer>> GetCustomerByClientId(Guid clientId)
        {
            return _customersService.GetAllByClientId(clientId);
        }

        [HttpGet("{customerId}")]
        public ActionResult<Customer> GetCustomer(Guid customerId)
        {
            var customer = _customersService.GetById(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut("{customerId}")]
        public ActionResult<Customer> PutCustomer(Guid customerId, Customer customer)
        {
            try
            {
                _customersService.Update(customerId, customer);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return customer;
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            try
            {
                _customersService.Delete(customerId);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpPut("{customerId}/status/{status}")]
        public ActionResult<Customer> PutCustomerStatus(Guid customerId, CustomerStatus status)
        {
            try
            {
                var customer = _customersService.UpdateCustomerStatus(customerId, status);
                return customer;
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
