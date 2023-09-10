using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public record Employee
    {
        public Guid Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<EmployeeService>? EmployeeServices { get; init; }
        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; init; }
    }
}