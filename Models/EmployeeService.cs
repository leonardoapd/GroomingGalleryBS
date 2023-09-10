using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public record EmployeeService
    {
        public Guid EmployeeId { get; set; }
        public Guid ServiceId { get; set; }

        // Navigation properties
        public Employee? Employee { get; set; }
        public Service? Service { get; set; }
    }
}