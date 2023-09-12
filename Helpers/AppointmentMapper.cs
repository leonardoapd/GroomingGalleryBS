using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.DTOs.EmployeeDTOs;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Helpers
{
    public static class AppointmentMapper
    {
        public static AppointmentDTO AsDTO(this Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Employee = new AppointmentEmployeeDTO
                {
                    Id = appointment.Employee!.Id,
                    FirstName = appointment.Employee!.FirstName,
                    LastName = appointment.Employee!.LastName,
                    PhoneNumber = appointment.Employee!.PhoneNumber,
                    Email = appointment.Employee!.Email,
                },
                Customer = new CustomerDTO
                {
                    Id = appointment.Customer!.Id,
                    FirstName = appointment.Customer!.FirstName,
                    LastName = appointment.Customer!.LastName,
                    PhoneNumber = appointment.Customer!.PhoneNumber,
                    Email = appointment.Customer!.Email
                },
                Service = new ServiceDTO
                {
                    Id = appointment.Service!.Id,
                    Name = appointment.Service!.Name,
                    Description = appointment.Service!.Description,
                    Price = appointment.Service!.Price,
                    DurationInMinutes = appointment.Service!.DurationInMinutes
                }
            };
        }
    }
}