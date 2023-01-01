using PSP.Enums;
using PSP.Models;
using System;
using System.Collections.Generic;

namespace PSP.Interfaces
{
    public interface ICustomersService
    {
        List<Customer> GetAll();
        Customer Create(Customer customer);
        List<Customer> GetAllByClientId(Guid id);
        Customer GetById(Guid id);
        Customer Update(Guid id, Customer customer);
        Customer UpdateCustomerStatus(Guid id, CustomerStatus status);
        void Delete(Guid id);

    }
}
