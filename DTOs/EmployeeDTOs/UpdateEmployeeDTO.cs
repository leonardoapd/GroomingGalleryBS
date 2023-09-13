using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.DTOs.EmployeeDTOs
{
    public class UpdateEmployeeDTO
    {
        [Required]
        public string? FirstName { get; init; }
        [Required]
        public string? LastName { get; init; }
        [Required]
        public string? PhoneNumber { get; init; }
        [Required]
        public string? Email { get; init; }
    }
}