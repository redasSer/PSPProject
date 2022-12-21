using System;
using System.Collections.Generic;
using PSP.Models;

namespace PSP.Interfaces;

public interface IPaymentsService
{
    List<Payment> GetAll();
    Payment GetById(Guid id);
    Payment Create(Payment payment);
    Payment Update(Guid id, Payment payment);
    void Delete(Guid id);
}