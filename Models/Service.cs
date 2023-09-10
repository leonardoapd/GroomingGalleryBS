using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public record Service
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public decimal Price { get; init; } 
        
        public int DurationInMinutes { get; init; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<EmployeeService>? EmployeeServices { get; init; }
        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; init; }
    }
}