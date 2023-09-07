using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.DTOs
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public EmployeeDTO Employee { get; set; } = null!;
        public ServiceDTO Service { get; set; } = null!;
        public CustomerDTO Customer { get; set; } = null!;
        
    }
}