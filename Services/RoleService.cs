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
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        private IQueryable<Role> Roles => _context.Roles;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAll()
        {
            return Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            return _context.Find<Role>(id);
        }

        public Role Create(Role role)
        {
            role.RoleId = new Guid();
            try
            {
                _context.Add<Role>(role);
                _context.SaveChanges();
                return role;
            }
            catch (DbUpdateException ex)
            {
                throw new SqlException("Bad query body. Possible reasons: ClientID does not exist");
            }
        }

        public Role Update(Guid id, Role role)
        {
            if (id != role.RoleId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(role).State = EntityState.Modified;

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
                throw new SqlException("Bad query body. Possible reasons: ClientID does not exist");

            }
            return role;
        }
     

        public void Delete(Guid id)
        {
            var Role = _context.Roles.Find(id);
            if (Role == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Roles.Remove(Role);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }
    }
}
