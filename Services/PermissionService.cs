using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSP.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDbContext _context;

        private IQueryable<Permission> Permissions => _context.Permissions;

        public PermissionService(AppDbContext context)
        {
            _context = context;
        }

        public List<Permission> GetAll()
        {
            return Permissions.ToList();
        }

        public Permission GetById(Guid id)
        {
            return _context.Find<Permission>(id);
        }

        public Permission Create(Permission permission)
        {
            try
            {
                permission.PermissionId = new Guid();
                _context.Add<Permission>(permission);
                _context.SaveChanges();
                return permission;
            }
            catch (DbUpdateException)
            {
                throw new SqlException("Bad query body. Possible reasons: ClientID or PermisionTypeID or RoleID does not exist");
            }

        }

        public Permission Update(Guid id, Permission permission)
        {
            if (id != permission.PermissionId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(permission).State = EntityState.Modified;

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
            catch (DbUpdateException ex)
            {
                throw new SqlException("Bad query body. Possible reasons: ClientID or PermisionTypeID or RoleID does not exist");
            }
            return permission;
        }
     

        public void Delete(Guid id)
        {
            var permission = _context.Permissions.Find(id);
            if (permission == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Permissions.Remove(permission);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.Permissions.Any(e => e.PermissionId == id);
        }
    }
}
