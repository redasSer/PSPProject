using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController
{
    private readonly IPaymentsService _paymentsService;

    public PaymentsController(IPaymentsService paymentsService)
    {
        _paymentsService = paymentsService;
    }

    [HttpGet]
    public List<Payment> GetAll()
    {
        return _paymentsService.GetAll().ToList();
    }

    [HttpGet("{id:guid}")]
    public Payment GetById(Guid id)
    {
        return _paymentsService.GetById(id);
    }
    
    [HttpPost]
    public Payment Create(Payment payment)
    {
        return _paymentsService.Create(payment);
    }
    
    [HttpPut("{id:guid}")]
    public Payment Update(Guid id, Payment payment)
    {
        return _paymentsService.Update(id, payment);
    }
    
    [HttpDelete("{id:guid}")]
    public void Delete(Guid id)
    {
        _paymentsService.Delete(id);
    }
}
    