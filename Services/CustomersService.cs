using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSP.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly AppDbContext _context;

        private IQueryable<Customer> Customers => _context.Customers;

        public CustomersService(AppDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAll()
        {
            return Customers.ToList();
        }

        public Customer Create(Customer customer)
        {
            customer.customerId = new Guid();
            _context.Add<Customer>(customer);
            _context.SaveChanges();
            return customer;
        }

        public List<Customer> GetAllByClientId(Guid id)
        {
            return Customers.Where(x => x.clientId == id).ToList();
        }

        public Customer GetById(Guid id)
        {
            return _context.Find<Customer>(id);
        }

        public Customer Update(Guid id, Customer customer)
        {
            if (id != customer.customerId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            return customer;
        }

        public Customer UpdateCustomerStatus(Guid id, CustomerStatus status)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                throw new SqlException("Model does not exists");
            }
            customer.status = status;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }

        public void Delete(Guid id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.customerId == id);
        }

    }
}
