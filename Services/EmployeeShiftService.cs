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
    public class EmployeeShiftService : IEmployeeShiftService
    {
        private readonly AppDbContext _context;

        private IQueryable<EmployeeShift> EmployeeShifts => _context.EmployeeShifts;

        public EmployeeShiftService(AppDbContext context)
        {
            _context = context;
        }

        public List<EmployeeShift> GetAll()
        {
            return EmployeeShifts.ToList();
        }

        public EmployeeShift GetById(Guid id)
        {
            return _context.Find<EmployeeShift>(id);
        }

        public EmployeeShift Create(EmployeeShift EmployeeShift)
        {
            EmployeeShift.EmployeeShiftId = new Guid();
            try
            {
                _context.Add<EmployeeShift>(EmployeeShift);
                _context.SaveChanges();
                return EmployeeShift;

            }
            catch (DbUpdateException)
            {
                throw new SqlException("Bad query body. Possible reasons: EmployeeID does not exist and/or LocationID does not exist");
            }
        }

        public EmployeeShift Update(Guid id, EmployeeShift employeeShift)
        {
            if (id != employeeShift.EmployeeShiftId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(employeeShift).State = EntityState.Modified;

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
            catch (DbUpdateException)
            {
                throw new SqlException("Bad query body. Possible reasons: EmployeeID does not exist and/or ShiftID does not exist");
            }
            return employeeShift;
        }
     

        public void Delete(Guid id)
        {
            var employeeShift = _context.EmployeeShifts.Find(id);
            if (employeeShift == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.EmployeeShifts.Remove(employeeShift);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.EmployeeShifts.Any(e => e.EmployeeShiftId == id);
        }
    }
}
