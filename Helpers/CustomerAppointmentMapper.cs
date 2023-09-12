using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.DTOs.AppointmentDTOs;
using GroomingGalleryBs.DTOs.EmployeeDTOs;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Helpers
{
    public static class CustomerAppointmentMapper
    {
        public static CustomerAppointmentsDTO AsDTO(Appointment appointment)
        {
            return new CustomerAppointmentsDTO
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
                Service = appointment.Service!.AsDTO()
            };
        }
    }
}