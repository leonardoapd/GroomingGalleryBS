using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.DTOs;
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
                var customers = await _customerRepository.GetAll();
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

        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(Guid id)
        {
            try
            {
                var customer = await _customerRepository.GetById(id);
                if (customer != null)
                {
                    var customerDto = new CustomerDTO
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email
                    };
                    return Ok(customerDto);
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
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            try
            {
                await _customerRepository.Create(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
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
        public async Task<ActionResult> UpdateCustomer(Guid id, [FromBody] CustomerDTO customerDTO) // [FromBody] Customer customer
        {
            try
            {
                var customer = await _customerRepository.GetById(id);
                if (customer != null)
                {
                    var updatedCustomer = new Customer
                    {
                        Id = customer.Id,
                        FirstName = customerDTO.FirstName ?? customer.FirstName,
                        LastName = customerDTO.LastName ?? customer.LastName,
                        PhoneNumber = customerDTO.PhoneNumber ?? customer.PhoneNumber,
                        Email = customerDTO.Email ?? customer.Email
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