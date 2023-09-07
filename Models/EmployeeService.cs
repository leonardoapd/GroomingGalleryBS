using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.Models
{
    public class EmployeeService
    {
        public Guid EmployeeId { get; set; }
        public Guid ServiceId { get; set; }
        public Employee Employee { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}