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
    public class ClientService : IEmployeeService
    {
        private readonly AppDbContext _context;

        private IQueryable<Employee> Employees => _context.Employees;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return Employees.ToList();
        }

        public Employee GetById(Guid id)
        {
            return _context.Find<Employee>(id);
        }

        public Employee Create(Employee employee)
        {
            employee.EmployeeId = new Guid();
            _context.Add<Employee>(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Update(Guid id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(employee).State = EntityState.Modified;

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
            return employee;
        }
     

        public void Delete(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        private bool entityExists(Guid id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
