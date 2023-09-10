using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GroomingGalleryBs.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? PhoneNumber { get; set; } 
        public string? Email { get; set; } 

        [JsonIgnore]
        public ICollection<ServiceDTO>? EmployeeServices { get; set; }
    }
}