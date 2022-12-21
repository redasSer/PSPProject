using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSP.Services
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;

        private IQueryable<Location> Locations => _context.Locations;

        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public List<Location> GetAll()
        {
            return Locations.ToList();
        }

        public Location GetById(Guid id)
        {
            return _context.Find<Location>(id);
        }

        public Location Create(Location location)
        {
            location.LocationId = new Guid();
            try
            {
                _context.Add<Location>(location);
                _context.SaveChanges();
                return location;
            }
            catch (DbUpdateException ex)
            {
                throw new SqlException("Bad query body. Possible reasons: ClientID does not exist");
            }
        }

        public Location Update(Guid id, Location location)
        {
            if (id != location.LocationId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return location;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entityExists(id))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new SqlException("Bad query body. Possible reasons: ClientID does not exist");
            }
        }
     

        public void Delete(Guid id)
        {
            var Location = _context.Locations.Find(id);
            if (Location == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Locations.Remove(Location);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
