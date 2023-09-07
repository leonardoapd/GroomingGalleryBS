using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
        public Guid ServiceId { get; set; }
        [JsonIgnore]
        public Service? Service { get; set; }
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }

    }
}