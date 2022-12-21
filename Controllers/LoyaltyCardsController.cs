using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSP.Enums;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoyaltyCardsController
{
    private readonly ILoyaltyCardService _loyaltyCardService;
    
    public LoyaltyCardsController(ILoyaltyCardService loyaltyCardService)
    {
        _loyaltyCardService = loyaltyCardService;
    }
    
    [HttpGet]
    public List<LoyaltyCard> GetAll()
    {
        return _loyaltyCardService.GetAll().ToList();
    }
    
    [HttpGet("{id}")]
    public LoyaltyCard Get(Guid id)
    {
        return _loyaltyCardService.GetById(id);
    }
    
    [HttpPost]
    public LoyaltyCard Create(LoyaltyCard loyaltyCard)
    {
        return _loyaltyCardService.Create(loyaltyCard);
    }
    
    [HttpGet("customer/{customerId:guid}")]
    public LoyaltyCard GetByCustomerId(Guid customerId)
    {
        return _loyaltyCardService.GetByCustomerId(customerId);
    }
    
    [HttpPut("{id:guid}")]
    public LoyaltyCard Update(Guid id, LoyaltyCard loyaltyCard)
    {
        return _loyaltyCardService.Update(id, loyaltyCard);
    }
    
    [HttpPut("customer/{cardId:guid}/status/{status}")]
    public LoyaltyCard UpdateStatus(Guid cardId, CardStatus status)
    {
        return _loyaltyCardService.UpdateStatus(cardId, status);
    }
    
    [HttpDelete("{id:guid}")]
    public void Delete(Guid id)
    {
        _loyaltyCardService.Delete(id);
    }
}