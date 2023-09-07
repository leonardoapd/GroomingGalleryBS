using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.Models;
using Microsoft.EntityFrameworkCore;

namespace GroomingGalleryBs.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly AppDBContext _context;

        public ServiceRepository(AppDBContext context)
        {
            _context = context;
        }

        public Task<Service> Create(Service service)
        {
            try
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return Task.FromResult(service);
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
                var service = _context.Services.FirstOrDefault(c => c.Id == id);

                if (service != null)
                {
                    _context.Services.Remove(service);
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

        public Task<IEnumerable<Service>> GetAll()
        {
            try
            {
                var services = _context.Services.ToList();
                return Task.FromResult(services.AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Service> GetById(Guid id)
        {
            try
            {
                var service = _context.Services.FirstOrDefault(s => s.Id == id);
                return Task.FromResult(service!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Update(Service service)
        {
            try
            {
                var existingService = _context.Services.FirstOrDefault(c => c.Id == service.Id);

                if (existingService != null)
                {
                    _context.Entry(existingService).State = EntityState.Detached;
                    _context.Services.Update(service);
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