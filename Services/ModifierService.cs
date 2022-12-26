using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Services
{
    public class ModifierService : IModifierService
    {
        private readonly AppDbContext _context;
        private IQueryable<Modifier> Modifiers => _context.Modifiers;

        public ModifierService(AppDbContext context)
        {
            _context = context;
        }

        public List<Modifier> GetAll()
        {
            return Modifiers.ToList();
        }

        public Modifier GetById(Guid modifierId)
        {
            return _context.Find<Modifier>(modifierId);
        }

        public Modifier Create(Modifier modifier)
        {
            var newId = new Guid();
            modifier.ModifierId = newId;
            _context.Add<Modifier>(modifier);

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new SqlException("Bad query parameters. Possible reasons: CatalogueItemId / ClientId / ItemId do not exist");
            }

            //return modifier;
            return GetById(newId);
        }

        public Modifier Update(Guid modifierId, Modifier modifier)
        {
            if (modifierId != modifier.ModifierId)
                throw new SqlException("Id does not match the received model id");

            _context.Entry(modifier).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(modifierId))
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
                throw new SqlException("Bad query parameters. Possible reasons: CatalogueItemId / ClientId / ItemId do not exist");
            }

            return GetById(modifierId);
        }

        public void Delete(Guid modifierId)
        {
            var modifier = _context.Modifiers.Find(modifierId);
            if (modifier == null)
                throw new SqlException("Entity does not exists");

            _context.Modifiers.Remove(modifier);
            _context.SaveChanges();

            if (_context.Find<Modifier>(modifierId) != null)
                throw new SqlException("Failed to delete entity");
        }

        private bool EntityExists(Guid modifierId)
        {
            return _context.Modifiers.Any(e => e.ModifierId == modifierId);
        }
    }
}
