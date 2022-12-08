using System;
using System.Collections.Generic;
using PSP.Models;

namespace PSP.Services
{
    public interface IBookingsService
    {
        List<Booking> GetAll();
        Booking GetById(Guid id);
        Booking Create(Booking booking);
    }
}