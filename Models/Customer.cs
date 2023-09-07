using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; set; }
    }
}