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
        public static EmployeeDTO MapToDTO(Employee employee)
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
                    Id = es.Service.Id,
                    Name = es.Service.Name,
                    Description = es.Service.Description,
                    Price = es.Service.Price,
                    DurationInMinutes = es.Service.DurationInMinutes
                }).ToList()
            };
        }


        // public static EmployeeDTO MapToDTO(Employee employee)
        // {
        //     return new EmployeeDTO
        //     {
        //         Id = employee.Id,
        //         FirstName = employee.FirstName,
        //         LastName = employee.LastName,
        //         Email = employee.Email,
        //         PhoneNumber = employee.PhoneNumber,
        //         EmployeeServices = employee.EmployeeServices?.Select(es => MapToServiceDTO(es.Service)).ToList()
        //     };
        // }

        // public static Employee MapFromDTO(EmployeeDTO employeeDTO)
        // {
        //     return new Employee
        //     {
        //         Id = employeeDTO.Id,
        //         FirstName = employeeDTO.FirstName,
        //         LastName = employeeDTO.LastName,
        //         Email = employeeDTO.Email,
        //         PhoneNumber = employeeDTO.PhoneNumber,
        //         EmployeeServices = employeeDTO.EmployeeServices?.Select(es => new EmployeeService
        //         {
        //             Service = MapFromServiceDTO(es)
        //         }).ToList()
        //     };
        // }

        // private static ServiceDTO MapToServiceDTO(Service service)
        // {
        //     return new ServiceDTO
        //     {
        //         Id = service.Id,
        //         Name = service.Name,
        //         Description = service.Description,
        //         Price = service.Price,
        //         DurationInMinutes = service.DurationInMinutes
        //     };
        // }

        // private static Service MapFromServiceDTO(ServiceDTO serviceDTO)
        // {
        //     return new Service
        //     {
        //         Id = serviceDTO.Id,
        //         Name = serviceDTO.Name!,
        //         Description = serviceDTO.Description!,
        //         Price = serviceDTO.Price,
        //         DurationInMinutes = serviceDTO.DurationInMinutes
        //     };
        // }
        public static Employee MapFromDTO(EmployeeDTO dto)
        {
            return new Employee
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                EmployeeServices = dto.EmployeeServices?.Select(es => new EmployeeService
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