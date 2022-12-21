using PSP.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PSP.Interfaces
{
    public interface IPermissionService
    {
        List<Permission> GetAll();
        Permission GetById(Guid id);
        Permission Create(Permission permission);
        Permission Update(Guid id, Permission permission);
        void Delete(Guid id);
    }
}
