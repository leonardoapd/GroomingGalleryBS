using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public double Price { get; set; } 
        [Required]
        public int DurationInMinutes { get; set; }
        [JsonIgnore]
        public ICollection<EmployeeService>? EmployeeServices { get; set; }
        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; set; }
    }
}