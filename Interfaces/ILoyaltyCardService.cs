using System;
using System.Collections.Generic;
using PSP.Enums;
using PSP.Models;

namespace PSP.Interfaces;

public interface ILoyaltyCardService
{
    List<LoyaltyCard> GetAll();
    LoyaltyCard GetById(Guid guid);
    LoyaltyCard GetByCustomerId(Guid customerId);
    LoyaltyCard Create(LoyaltyCard loyaltyCard);
    LoyaltyCard Update(Guid guid, LoyaltyCard loyaltyCard);
    LoyaltyCard UpdateStatus(Guid guid, CardStatus status);
    void Delete(Guid guid);
}