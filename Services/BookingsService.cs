using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Data;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Services;

public class BookingService : IBookingsService
{
    private readonly AppDbContext _db;

    private IQueryable<Booking> Bookings => _db.Bookings;

    public BookingService(AppDbContext db)
    {
        _db = db;
    }
    
    public List<Booking> GetAll()
    {
        return Bookings.ToList();
    }

    public Booking GetById(Guid id)
    {
        return _db.Bookings.Find(id);
    }
    public Booking Create(Booking booking)
    {
        Booking newBooking = new Booking();
        
        newBooking.bookingId = Guid.NewGuid();
        newBooking.description = booking.description;
        newBooking.time = DateTime.Now;
        newBooking.orderId = booking.orderId;
        
        _db.Bookings.Add(newBooking);
        _db.SaveChanges();
        
        return newBooking;
    }

    public Booking Update(Guid id, Booking booking)
    {
        var bookingToUpdate = _db.Bookings.Find(id);
        bookingToUpdate.description = booking.description;
        bookingToUpdate.time = booking.time;
        bookingToUpdate.orderId = booking.orderId;
        
        _db.SaveChanges();

        return bookingToUpdate;
    }

    public void Delete(Guid id)
    {
        var booking = _db.Bookings.Find(id);
        _db.Bookings.Remove(booking);
        _db.SaveChanges();
    }
}