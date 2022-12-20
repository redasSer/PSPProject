using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Data;
using PSP.Enums;
using PSP.Models;

namespace PSP.Services;

public class LoyaltyCardService : ILoyaltyCardService
{
    private readonly AppDbContext _db;
    
    private IQueryable<LoyaltyCard> LoyaltyCards => _db.LoyaltyCards;
    
    public LoyaltyCardService(AppDbContext db)
    {
        _db = db;
    }
    
    public List<LoyaltyCard> GetAll()
    {
        return LoyaltyCards.ToList();
    }

    public LoyaltyCard GetById(Guid guid)
    {
        return _db.LoyaltyCards.Find(guid);
    }

    public LoyaltyCard GetByCustomerId(Guid customerId)
    {
        return _db.LoyaltyCards.FirstOrDefault(x => x.customerId == customerId);
    }

    public LoyaltyCard Create(LoyaltyCard loyaltyCard)
    {
        LoyaltyCard newLoyaltyCard = new LoyaltyCard();
        
        newLoyaltyCard.customerId = loyaltyCard.customerId;
        newLoyaltyCard.cardId = Guid.NewGuid();
        newLoyaltyCard.clientId = loyaltyCard.clientId;
        newLoyaltyCard.status = 0;
        newLoyaltyCard.loyaltyPoints = 0;

        _db.LoyaltyCards.Add(newLoyaltyCard);
        _db.SaveChanges();

        return newLoyaltyCard;
    }

    public LoyaltyCard Update(Guid id, LoyaltyCard loyaltyCard)
    {
        var loyaltyCardToUpdate = _db.LoyaltyCards.Find(id);
        if (loyaltyCardToUpdate == null)
            return null;
        loyaltyCardToUpdate.status = loyaltyCard.status;
        loyaltyCardToUpdate.loyaltyPoints = loyaltyCard.loyaltyPoints;
        loyaltyCardToUpdate.clientId = loyaltyCard.clientId;
        loyaltyCardToUpdate.customerId = loyaltyCard.customerId;
        _db.SaveChanges();
        
        return loyaltyCardToUpdate;
    }

    public LoyaltyCard UpdateStatus(Guid guid, CardStatus status)
    {
        var loyaltyCardToUpdate = _db.LoyaltyCards.Find(guid);
        if (loyaltyCardToUpdate == null)
            return null;
        loyaltyCardToUpdate.status = status;
        _db.SaveChanges();
        
        return loyaltyCardToUpdate;
    }

    public void Delete(Guid guid)
    {
        var LoyaltyCardToDelete = _db.LoyaltyCards.Find(guid);

        _db.LoyaltyCards.Remove(LoyaltyCardToDelete);
        _db.SaveChanges();
    }
}