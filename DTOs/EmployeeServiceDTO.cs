using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.DTOs
{
    public record EmployeeServiceDTO
    {
        public Guid EmployeeId { get; set; }
        public Guid ServiceId { get; set; }
    }
}