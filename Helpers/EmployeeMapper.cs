using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Helpers
{
    public static class EmployeeMapper 
    {
        public static EmployeeDTO AsDTO(this Employee employee)
        {
            return new EmployeeDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                EmployeeServices = employee.EmployeeServices?.Select(es => new ServiceDTO
                {
                    Id = es.Service!.Id,
                    Name = es.Service.Name,
                    Description = es.Service.Description,
                    Price = es.Service.Price,
                    DurationInMinutes = es.Service.DurationInMinutes
                }).ToList()
            };
        }

        public static Employee FromDTO(this EmployeeDTO employeeDTO)
        {
            return new Employee
            {
                Id = employeeDTO.Id,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Email = employeeDTO.Email,
                PhoneNumber = employeeDTO.PhoneNumber,
                EmployeeServices = employeeDTO.EmployeeServices?.Select(es => new EmployeeService
                {
                    Service = new Service
                    {
                        Id = es.Id,
                        Name = es.Name!,
                        Description = es.Description!,
                        Price = es.Price,
                        DurationInMinutes = es.DurationInMinutes
                    }
                }).ToList()
            };
        }

        
    }
}