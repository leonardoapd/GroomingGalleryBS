using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Repositories;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Repositories
{
   public class EmployeeServiceRepository : IEmployeeServiceRepository
    {
        private readonly AppDBContext _context;

        public EmployeeServiceRepository(AppDBContext context)
        {
            _context = context;
        }

        public Task AddEmployeeService(Guid employeeId, Guid serviceId)
        {
            try
            {
                var employeeService = _context.EmployeeServices.FirstOrDefault(es => es.EmployeeId == employeeId && es.ServiceId == serviceId);

                if (employeeService != null)
                {
                    throw new Exception("Employee already has this service");
                }

                _context.EmployeeServices.Add(new EmployeeService()
                {
                    EmployeeId = employeeId,
                    ServiceId = serviceId
                });

                _context.SaveChanges();

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Service>> GetEmployeeServices(Guid employeeId)
        {
            try
            {
                var services = _context.EmployeeServices.
                    Where(es => es.EmployeeId == employeeId).
                    Select(es => es.Service).
                    ToList();

                return Task.FromResult(services.AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task RemoveEmployeeService(Guid employeeId, Guid serviceId)
        {
            throw new NotImplementedException();
        }
    }
}