using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.Helpers;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroomingGalleryBs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentController(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAll();
                
                var appointmentDTOs = new List<AppointmentDTO>();

                foreach (var appointment in appointments)
                {
                    var appointmentDTO = AppointmentMapper.MapToDTO(appointment);
                    appointmentDTOs.Add(appointmentDTO);
                }

                return Ok(appointmentDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(AppointmentDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointment(Guid id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetById(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                var appointmentDTO = AppointmentMapper.MapToDTO(appointment);            
                return Ok(appointmentDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Appointment), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] Appointment appointment)
        {
            try
            {
                var newAppointment = await _appointmentRepository.Create(appointment);
                return Ok(newAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}