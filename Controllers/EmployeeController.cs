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
                var employees = await _employeeRepository.GetAll();

                var employeeDtos = employees.Select(employee => EmployeeMapper.MapToDTO(employee)).ToList();

                return Ok(employeeDtos);
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
                    var employeeDto = EmployeeMapper.MapToDTO(employee);
                    return Ok(employeeDto);
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
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                await _employeeRepository.Create(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
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
        public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeDTO employeeDto)
        {
            try
            {
                var employee = await _employeeRepository.GetById(id);
                if (employee != null)
                {
                    var updatedEmployee = new Employee
                    {
                        Id = employee.Id,
                        FirstName = employeeDto.FirstName ?? employee.FirstName,
                        LastName = employeeDto.LastName ?? employee.LastName,
                        Email = employeeDto.Email ?? employee.Email,
                        PhoneNumber = employeeDto.PhoneNumber ?? employee.PhoneNumber
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