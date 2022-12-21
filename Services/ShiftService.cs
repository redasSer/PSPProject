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
    public class ShiftService : IShiftService
    {
        private readonly AppDbContext _context;

        private IQueryable<Shift> Shifts => _context.Shifts;

        public ShiftService(AppDbContext context)
        {
            _context = context;
        }

        public List<Shift> GetAll()
        {
            return Shifts.ToList();
        }

        public Shift GetById(Guid id)
        {
            return _context.Find<Shift>(id);
        }

        public Shift Create(Shift shift)
        {
            shift.ShiftId = new Guid();
            _context.Add<Shift>(shift);
            _context.SaveChanges();
            return shift;
        }

        public Shift Update(Guid id, Shift shift)
        {
            if (id != shift.ShiftId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(shift).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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
            return shift;
        }
     

        public void Delete(Guid id)
        {
            var shift = _context.Shifts.Find(id);
            if (shift == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Shifts.Remove(shift);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.Shifts.Any(e => e.ShiftId == id);
        }
    }
}
