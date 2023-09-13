using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Helpers
{
    public static class ServiceMapper
    {
        public static ServiceDTO AsDTO(this Service service)
        {
            return new ServiceDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                DurationInMinutes = service.DurationInMinutes
            };
        }

        public static Service FromDTO(this ServiceDTO serviceDTO)
        {
            return new Service
            {
                Id = serviceDTO.Id,
                Name = serviceDTO.Name!,
                Description = serviceDTO.Description!,
                Price = serviceDTO.Price,
                DurationInMinutes = serviceDTO.DurationInMinutes
            };
        }
    }
}