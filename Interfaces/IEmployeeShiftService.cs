using PSP.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PSP.Interfaces
{
    public interface IEmployeeShiftService
    {
        List<EmployeeShift> GetAll();
        EmployeeShift GetById(Guid id);
        EmployeeShift Create(EmployeeShift employeeShift);
        EmployeeShift Update(Guid id, EmployeeShift employeeShift);
        void Delete(Guid id);
    }
}
