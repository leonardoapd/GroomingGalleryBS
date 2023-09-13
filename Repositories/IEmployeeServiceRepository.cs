using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Repositories
{
    public interface IEmployeeServiceRepository
    {
        public Task<IEnumerable<Service>> GetEmployeeServices(Guid employeeId);
        public Task AddEmployeeService(Guid employeeId, Guid serviceId);
        public Task RemoveEmployeeService(Guid employeeId, Guid serviceId);       
    }
}