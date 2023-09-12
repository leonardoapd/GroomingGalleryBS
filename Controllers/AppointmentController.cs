using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.DTOs.AppointmentDTOs;
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
        private readonly IEmployeeServiceRepository _employeeServiceRepository;

        public AppointmentController(IRepository<Appointment> appointmentRepository, IEmployeeServiceRepository employeeServiceRepository)
        {
            _appointmentRepository = appointmentRepository;
            _employeeServiceRepository = employeeServiceRepository;
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
                    var appointmentDTO = appointment.AsDTO();
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

                var appointmentDTO = appointment.AsDTO();
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
                var employeServices = await _employeeServiceRepository.GetEmployeeServices(appointment.EmployeeId);
                var service = employeServices.FirstOrDefault(s => s.Id == appointment.ServiceId);
                if (service == null)
                {
                    throw new Exception("Employee does not have this service");
                }

                var newAppointment = await _appointmentRepository.Create(appointment);
                return Ok(newAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(CustomerAppointmentsDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("Customer/{id}")]
        public async Task<ActionResult<CustomerAppointmentsDTO>> GetCustomerAppointments(Guid id)
        {
            try
            {
                var appointments = await _appointmentRepository.GetAll();
                if (appointments == null || appointments.FirstOrDefault(a => a.CustomerId == id) == null)
                {
                    return NotFound();
                }

                List<CustomerAppointmentsDTO> customerAppointmentsDTOs = new List<CustomerAppointmentsDTO>();

                foreach (var appointment in appointments)
                {
                    if (appointment.CustomerId == id)
                    {
                        var customerAppointmentsDTO = CustomerAppointmentMapper.AsDTO(appointment);
                        customerAppointmentsDTOs.Add(customerAppointmentsDTO);
                    }
                }

                return Ok(customerAppointmentsDTOs);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(EmployeeAppointmentsDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<EmployeeAppointmentsDTO>> GetEmployeeAppointments(Guid id)
        {
            try
            {
                var appointments = await _appointmentRepository.GetAll();
                if (appointments == null || appointments.FirstOrDefault(a => a.EmployeeId == id) == null)
                {
                    return NotFound();
                }

                List<EmployeeAppointmentsDTO> employeeAppointmentsDTOs = new List<EmployeeAppointmentsDTO>();

                foreach (var appointment in appointments)
                {
                    if (appointment.EmployeeId == id)
                    {
                        var employeeAppointmentsDTO = EmployeeAppointmentMapper.AsDTO(appointment);
                        employeeAppointmentsDTOs.Add(employeeAppointmentsDTO);
                    }
                }

                return Ok(employeeAppointmentsDTOs);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}