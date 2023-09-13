using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.Repositories;
using Microsoft.AspNetCore.Mvc;
using GroomingGalleryBs.Helpers;
using GroomingGalleryBs.DTOs.ServiceDTOs;

namespace GroomingGalleryBs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _serviceRepository;

        public ServiceController(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [ProducesResponseType(typeof(IEnumerable<Service>), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            try
            {
                var services = (await _serviceRepository.GetAll())
                                .Select(service => service.AsDTO());

                if (services != null)
                {
                    return Ok(services);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Service), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(Guid id)
        {
            try
            {
                var service = await _serviceRepository.GetById(id);
                if (service is null)
                {
                    return NotFound();
                }
                return Ok(service.AsDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Service), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> CreateService(CreateServiceDTO serviceDTO)
        {
            Service service = new()
            {
                Name = serviceDTO.Name!,
                Description = serviceDTO.Description!,
                Price = serviceDTO.Price,
                DurationInMinutes = serviceDTO.DurationInMinutes
            };

            try
            {
                await _serviceRepository.Create(service);
                return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Service), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateService(Guid id, [FromBody] UpdateServiceDTO serviceDTO)
        {
            try
            {
                var service = await _serviceRepository.GetById(id);
                if (service == null)
                {
                    return NotFound();
                }

                Service updatedService = service with
                {
                    Name = serviceDTO.Name!,
                    Description = serviceDTO.Description!,
                    Price = serviceDTO.Price,
                    DurationInMinutes = serviceDTO.DurationInMinutes
                };

                await _serviceRepository.Update(updatedService);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Service), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(Guid id)
        {
            try
            {
                var service = await _serviceRepository.Delete(id);
                if (service)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}