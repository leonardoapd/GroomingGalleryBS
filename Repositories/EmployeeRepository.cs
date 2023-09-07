using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.Models;
using Microsoft.EntityFrameworkCore;

namespace GroomingGalleryBs.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly AppDBContext _context;

        public EmployeeRepository(AppDBContext context)
        {
            _context = context;
        }

        public Task<Employee> Create(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return Task.FromResult(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                var employees = _context.Employees.ToList();
                return Task.FromResult(employees.AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Employee> GetById(Guid id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                return Task.FromResult(employee!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Update(Employee employee)
        {
            try
            {
                var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

                if (existingEmployee != null)
                {
                    _context.Entry(existingEmployee).State = EntityState.Detached;
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}