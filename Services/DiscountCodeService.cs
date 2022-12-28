using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System.Linq;

namespace PSP.Services
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly AppDbContext _context;

        private IQueryable<DiscountCode> DiscountCodes => _context.DiscountCodes;

        public DiscountCodeService(AppDbContext context)
        {
            _context = context;
        }

        public DiscountCode Create(DiscountCode discountCode)
        {
            _context.Add<DiscountCode>(discountCode);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: ClientId does not exist");
            }

            return discountCode;
        }

        public DiscountCode Update(string code, DiscountCode discountCode)
        {
            if (!code.Equals(discountCode.Code))
            {
                throw new SqlException("Code does not match the received model Code");
            }

            _context.Entry(discountCode).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entityExists(code))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL RELATION ERROR");
                }
            }
            catch (DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: ClientId does not exist");

            }

            return discountCode;
        }

        /*
        NOTE: Does not work because this endpoint is defined as using only one of the primary keys to find a and edit the discountCode 
        */
        public DiscountCode UpdateStatus(string code, DiscountCodeStatus status)
        {
            var discountCode = _context.DiscountCodes.Find(Equals(code));       //primary key not full error
            if (discountCode == null)
            {
                throw new SqlException("Code does not exist");
            }

            discountCode.Status = status;
            _context.Entry(discountCode).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entityExists(code))
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
                throw new SqlException("Bad query parameters. Possible reasons: ClientId does not exist");
            }

            return discountCode;
        }

        private bool entityExists(string code)
        {
            return _context.DiscountCodes.Any(e => e.Code.Equals(code));
        }
    }
}
