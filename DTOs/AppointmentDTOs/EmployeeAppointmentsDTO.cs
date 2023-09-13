using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.DTOs.AppointmentDTOs
{
    public record EmployeeAppointmentsDTO
    {
        public Guid Id { get; init; }
        public DateTimeOffset AppointmentDate { get; init; }
        public CustomerDTO Customer { get; init; } = null!;
        public ServiceDTO Service { get; init; } = null!;
    }
}