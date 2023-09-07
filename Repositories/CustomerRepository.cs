using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.Models;
using Microsoft.EntityFrameworkCore;

namespace GroomingGalleryBs.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AppDBContext _context;

        public CustomerRepository(AppDBContext context)
        {
            _context = context;
        }

        public Task<Customer> Create(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Task.FromResult(customer);
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
                var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

                if (customer != null)
                {
                    _context.Customers.Remove(customer);
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

        public Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var customers = _context.Customers.ToList();
                // customers.ForEach(costumer =>
                // {
                //     costumer.Appointments = _context.Appointments
                //     .Where(a => a.CustomerId == costumer.Id).ToList();
                // });
                return Task.FromResult(customers.AsEnumerable());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Customer> GetById(Guid id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
                return Task.FromResult(customer!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Update(Customer customer)
        {
            try
            {
                var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);

                if (existingCustomer != null)
                {
                    _context.Entry(existingCustomer).State = EntityState.Detached;
                    _context.Customers.Update(customer);
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