using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface IEmployeeCardService
    {
        List<EmployeeCard> GetAll();
        EmployeeCard GetById(Guid id);
        EmployeeCard Create(EmployeeCard employeeCard);
        EmployeeCard Update(Guid id, EmployeeCard employeeCard);
        EmployeeCard UpdateStatus(Guid id, int status);
        void Delete(Guid id);
    }
}
