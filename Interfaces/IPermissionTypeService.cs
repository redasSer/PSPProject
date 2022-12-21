using PSP.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PSP.Interfaces
{
    public interface IPermissionTypeService
    {
        List<PermissionType> GetAll();
        PermissionType GetById(Guid id);
        PermissionType Create(PermissionType permissionType);
        PermissionType Update(Guid id, PermissionType permissionType);
        void Delete(Guid id);
    }
}
