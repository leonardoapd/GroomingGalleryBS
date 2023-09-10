using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.DTOs
{
    public record AppointmentDTO
    {
        public Guid Id { get; init; }
        public DateTimeOffset AppointmentDate { get; init; }
        public EmployeeDTO Employee { get; init; } = null!;
        public ServiceDTO Service { get; init; } = null!;
        public CustomerDTO Customer { get; init; } = null!;
        
    }
}