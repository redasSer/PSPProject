using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Data;
using PSP.Enums;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Services;

public class PaymentsService : IPaymentsService
{
    private readonly AppDbContext _db;
    
    public PaymentsService(AppDbContext db)
    {
        _db = db;
    }

    private IQueryable<Payment> Payments => _db.Payments;
    
    public List<Payment> GetAll()
    {
        return Payments.ToList();
    }

    public Payment GetById(Guid id)
    {
        return _db.Payments.Find(id);
    }

    public Payment Create(Payment payment)
    {
        Payment newPayment = new Payment();
        
        newPayment.id = Guid.NewGuid();
        newPayment.clientId = payment.clientId;
        newPayment.orderId = payment.orderId;
        newPayment.amount = payment.amount;
        newPayment.comment = payment.comment;
        newPayment.date = DateTime.Now;
        newPayment.status = PaymentStatus.NOT_PAID;
        newPayment.method = payment.method;
        
        _db.Payments.Add(newPayment);
        _db.SaveChanges();
        
        return newPayment;
    }

    public Payment Update(Guid id, Payment payment)
    {
        var paymentToUpdate = _db.Payments.Find(id);
        
        paymentToUpdate.amount = payment.amount;
        paymentToUpdate.comment = payment.comment;
        paymentToUpdate.method = payment.method;
        paymentToUpdate.status = payment.status;
        
        _db.Payments.Update(paymentToUpdate);
        _db.SaveChanges();
        
        return paymentToUpdate;
    }

    public void Delete(Guid id)
    {
        var paymentToDelete = _db.Payments.Find(id);
        
        _db.Payments.Remove(paymentToDelete);
        _db.SaveChanges();
    }
}