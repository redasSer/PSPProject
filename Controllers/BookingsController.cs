using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers;

[ApiController]
    [Route("api/[controller]")] ///api/booking
    public class BookingController
    {
        private readonly IBookingsService _bookingsService;

        public BookingController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpGet]
        public List<Booking> GetAll()
        {
            var Bookings = _bookingsService.GetAll();
            return Bookings.ToList();
        }

        [HttpGet("{id:guid}")]
        public Booking GetById(Guid id)
        {
            return _bookingsService.GetById(id);
        }

        [HttpPost]
        public Booking Create(Booking booking)
        {
            return _bookingsService.Create(booking);
        }

        [HttpPatch("{id:guid}")]
        public Booking Update(Guid id, Booking booking)
        {
            return _bookingsService.Update(id, booking);
        }

        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _bookingsService.Delete(id);
        }
    }
