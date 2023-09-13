using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroomingGalleryBs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeServiceController : ControllerBase
    {
        private readonly IEmployeeServiceRepository _employeeServiceRepository;

        public EmployeeServiceController(IEmployeeServiceRepository employeeServiceRepository)
        {
            _employeeServiceRepository = employeeServiceRepository;
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPost]
        public async Task<ActionResult> AddEmployeeService(EmployeeServiceDTO employeeServiceDTO)
        {
            try
            {
                await _employeeServiceRepository.AddEmployeeService(employeeServiceDTO.EmployeeId, employeeServiceDTO.ServiceId);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(IEnumerable<Service>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<IEnumerable<Service>>> GetEmployeeServices(Guid employeeId)
        {
            try
            {
                var services = await _employeeServiceRepository.GetEmployeeServices(employeeId);
                return Ok(services);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}