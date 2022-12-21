using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSP.Services
{
    public class EmployeeCardService : IEmployeeCardService
    {
        private readonly AppDbContext _context;

        private IQueryable<EmployeeCard> EmployeeCards => _context.EmployeeCards;

        public EmployeeCardService(AppDbContext context)
        {
            _context = context;
        }

        public List<EmployeeCard> GetAll()
        {
            return EmployeeCards.ToList();
        }

        public EmployeeCard GetById(Guid id)
        {
            return _context.Find<EmployeeCard>(id);
        }

        public EmployeeCard Create(EmployeeCard employeeCard)
        {
            employeeCard.EmployeeCardId = new Guid();
            try
            {
                _context.Add<EmployeeCard>(employeeCard);
                _context.SaveChanges();
                return employeeCard;

            }
            catch (DbUpdateException)
            {
                throw new SqlException("Bad query body. Possible reasons: EmployeeID does not exist and/or LocationID does not exist");
            }
        }

        public EmployeeCard Update(Guid id, EmployeeCard employeeCard)
        {
            if (id != employeeCard.EmployeeCardId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(employeeCard).State = EntityState.Modified;

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
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                throw new SqlException("Bad query body. Possible reasons: EmployeeID does not exist and/or LocationID does not exist");
            }
            return employeeCard;
        }
     

        public void Delete(Guid id)
        {
            var EmployeeCard = _context.EmployeeCards.Find(id);
            if (EmployeeCard == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.EmployeeCards.Remove(EmployeeCard);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.EmployeeCards.Any(e => e.EmployeeCardId == id);
        }

        public EmployeeCard UpdateStatus(Guid id, int status)
        {
            if (status > Enum.GetValues(typeof(CardStatus)).Cast<int>().Max())
            {
                throw new SqlException("Bad query parameters. Card status out of range");
            }
            EmployeeCard employeeCard= _context.Find<EmployeeCard>(id); 
            if (employeeCard == null)
            {
                throw new SqlException("Employee card with this id does not exist");
            }
            employeeCard.Status = (CardStatus)status;
            _context.Entry(employeeCard).State = EntityState.Modified;

            try
            {
                _context.Entry(employeeCard).State = EntityState.Modified;
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

            return employeeCard;
        }
    }
}
