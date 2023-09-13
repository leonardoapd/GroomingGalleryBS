using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs.AppointmentDTOs;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Helpers
{
    public static class EmployeeAppointmentMapper
    {
        public static EmployeeAppointmentsDTO AsDTO(Appointment appointment)
        {
            return new EmployeeAppointmentsDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Customer = appointment.Customer!.AsDTO(),
                Service = appointment.Service!.AsDTO()
            };
        }
    }
}