using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Data;
using PSP.Models;

namespace PSP.Services
{
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
            return _db.Bookings.FirstOrDefault(o => o.bookingId == id);
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
    }
}