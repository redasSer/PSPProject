using PSP.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PSP.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(Guid id);
        Employee Create(Employee employee);
        Employee Update(Guid id, Employee employee);
        void Delete(Guid id);
    }
}
