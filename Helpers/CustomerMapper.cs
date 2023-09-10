using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.DTOs;
using GroomingGalleryBs.Models;

namespace GroomingGalleryBs.Helpers
{
    public static class CustomerMapper
    {
        public static CustomerDTO MapToDTO(Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };
        }

        public static Customer MapFromDTO(CustomerDTO customerDTO)
        {
            return new Customer
            {
                Id = customerDTO.Id,
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                PhoneNumber = customerDTO.PhoneNumber,
                Email = customerDTO.Email
            };
        }
    }
}