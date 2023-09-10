using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GroomingGalleryBs.DTOs
{
    public record EmployeeDTO
    {
        public Guid Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; } 
        public string? PhoneNumber { get; init; } 
        public string? Email { get; init; } 

        [JsonIgnore]
        public ICollection<ServiceDTO>? EmployeeServices { get; init; }
    }
}