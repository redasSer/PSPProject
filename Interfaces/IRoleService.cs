using System.Collections.Generic;
using System;
using PSP.Models;

namespace PSP.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetAll();
        Role GetById(Guid id);
        Role Create(Role role);
        Role Update(Guid id, Role role);
        void Delete(Guid id);
    }
}
