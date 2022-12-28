using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface IModifierService
    {
        List<Modifier> GetAll();
        Modifier GetById(Guid id);
        Modifier Create(Modifier modifier);
        Modifier Update(Guid id, Modifier modifier);
        void Delete(Guid id);
    }
}
