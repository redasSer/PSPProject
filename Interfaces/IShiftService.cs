using PSP.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PSP.Interfaces
{
    public interface IShiftService
    {
        List<Shift> GetAll();
        Shift GetById(Guid id);
        Shift Create(Shift shift);
        Shift Update(Guid id, Shift shift);
        void Delete(Guid id);
    }
}
