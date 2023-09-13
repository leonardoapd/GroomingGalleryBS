using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs.EmployeeDTOs;

namespace GroomingGalleryBs.DTOs.AppointmentDTOs
{
    public record CustomerAppointmentsDTO
    {
        public Guid Id { get; init; }
        public DateTimeOffset AppointmentDate { get; init; }
        public AppointmentEmployeeDTO Employee { get; init; } = null!;
        public ServiceDTO Service { get; init; } = null!;


    }
}