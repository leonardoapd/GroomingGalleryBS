using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingGalleryBs.DTOs.ServiceDTOs
{
    public record UpdateServiceDTO
    {
        [Required]
        public string? Name { get; init; }
        [Required]
        public string? Description { get; init; }
        [Required]
        public decimal Price { get; init; }
        [Required]
        public int DurationInMinutes { get; init; }
    }
}