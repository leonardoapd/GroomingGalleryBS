using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.DTOs.CustomerDTOs;
using GroomingGalleryBs.Helpers;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroomingGalleryBs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Appointment> _appointmentRepository;

        public CustomerController(IRepository<Customer> customerRepository, IRepository<Appointment> appointmentRepository)
        {
            _customerRepository = customerRepository;
            _appointmentRepository = appointmentRepository;
        }

        [ProducesResponseType(typeof(IEnumerable<Customer>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                var customers = (await _customerRepository.GetAll())
                                .Select(customer => customer.AsDTO());
                if (customers != null)
                {
                    return Ok(customers);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(CustomerDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(Guid id)
        {
            try
            {
                Customer customer = await _customerRepository.GetById(id);
                if (customer != null)
                {
                    return Ok(customer.AsDTO());
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(Customer), 201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CreateCustomerDTO customerDTO)
        {
            Customer customer = new ()
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                PhoneNumber = customerDTO.PhoneNumber,
                Email = customerDTO.Email
            };

            try
            {
                await _customerRepository.Create(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customerDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerDTO customerDTO) // [FromBody] Customer customer
        {
            try
            {
                var existingCustomer = await _customerRepository.GetById(id);
                if (existingCustomer != null)
                {
                    Customer updatedCustomer = existingCustomer with
                    {
                        FirstName = customerDTO.FirstName,
                        LastName = customerDTO.LastName,
                        PhoneNumber = customerDTO.PhoneNumber,
                        Email = customerDTO.Email
                    };
                    
                    await _customerRepository.Update(updatedCustomer);
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
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            try
            {
                var customer = await _customerRepository.Delete(id);
                if (customer)
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