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
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly AppDbContext _context;

        private IQueryable<PermissionType> PermissionTypes => _context.PermissionTypes;

        public PermissionTypeService(AppDbContext context)
        {
            _context = context;
        }

        public List<PermissionType> GetAll()
        {
            return PermissionTypes.ToList();
        }

        public PermissionType GetById(Guid id)
        {
            return _context.Find<PermissionType>(id);
        }

        public PermissionType Create(PermissionType permissionType)
        {
            permissionType.PermissionTypeId = new Guid();
            _context.Add<PermissionType>(permissionType);
            _context.SaveChanges();
            return permissionType;
        }

        public PermissionType Update(Guid id, PermissionType permissionType)
        {
            if (id != permissionType.PermissionTypeId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(permissionType).State = EntityState.Modified;

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
            return permissionType;
        }
     

        public void Delete(Guid id)
        {
            var permissionType = _context.PermissionTypes.Find(id);
            if (permissionType == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.PermissionTypes.Remove(permissionType);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.PermissionTypes.Any(e => e.PermissionTypeId == id);
        }
    }
}
