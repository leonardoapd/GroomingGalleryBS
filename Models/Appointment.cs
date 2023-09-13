using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public record Appointment
    {
        public Guid Id { get; init; }
        public DateTimeOffset AppointmentDate { get; init; }

        // Navigation properties
        public Guid EmployeeId { get; init; }
        public Guid ServiceId { get; init; }
        public Guid CustomerId { get; init; }
        
        [JsonIgnore]
        public Service? Service { get; init; }
        [JsonIgnore]
        public Customer? Customer { get; init; }
        [JsonIgnore]
        public Employee? Employee { get; init; }

    }
}