using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.DTOs.EmployeeDTOs;
using GroomingGalleryBs.Helpers;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroomingGalleryBs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [ProducesResponseType(typeof(IEnumerable<EmployeeDTO>), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            try
            {
                var employees = (await _employeeRepository.GetAll())
                                .Select(employee => employee.AsDTO());

                if (employees != null)  
                {
                    return Ok(employees);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(EmployeeDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(Guid id)
        {
            try
            {
                var employee = await _employeeRepository.GetById(id);
                if (employee != null)
                {
                    return Ok(employee.AsDTO());
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Employee), 201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDTO employeeDTO)
        {
            Employee employee = new ()
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Email = employeeDTO.Email,
                PhoneNumber = employeeDTO.PhoneNumber
            };

            try
            {
                await _employeeRepository.Create(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employeeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDTO employeeDto)
        {
            try
            {
                var existingEmployee = await _employeeRepository.GetById(id);
                if (existingEmployee != null)
                {
                    Employee updatedEmployee = existingEmployee with
                    {
                        FirstName = employeeDto.FirstName,
                        LastName = employeeDto.LastName,
                        Email = employeeDto.Email,
                        PhoneNumber = employeeDto.PhoneNumber
                    };

                    await _employeeRepository.Update(updatedEmployee);
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _employeeRepository.Delete(id);
                if (employee)
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