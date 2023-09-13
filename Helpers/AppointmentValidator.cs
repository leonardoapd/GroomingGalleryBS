using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Models;
using GroomingGalleryBs.Repositories;

namespace GroomingGalleryBS.Helpers
{
    public class AppointmentValidator
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly IEmployeeServiceRepository _employeeServiceRepository;

        public AppointmentValidator(
            IRepository<Employee> employeeRepository,
            IRepository<Customer> customerRepository,
            IRepository<Service> serviceRepository,
            IEmployeeServiceRepository employeeServiceRepository)
        {
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _serviceRepository = serviceRepository;
            _employeeServiceRepository = employeeServiceRepository;
        }

        public void IsAppointmentDataValid(Appointment appointment)
        {
            if (appointment.AppointmentDate < DateTimeOffset.Now)
            {
                throw new Exception("Appointment date cannot be in the past.");
            }

            var employee = _employeeRepository.GetById(appointment.EmployeeId);
            if (employee.Result == null)
            {
                throw new Exception("Employee does not exist.");
            }

            var customer = _customerRepository.GetById(appointment.CustomerId);
            if (customer.Result == null)
            {
                throw new Exception("Customer does not exist.");
            }

            var service = _serviceRepository.GetById(appointment.ServiceId);
            if (service.Result == null)
            {
                throw new Exception("Service does not exist.");
            }

            var employeServices = _employeeServiceRepository.GetEmployeeServices(appointment.EmployeeId);

            if (employeServices.Result == null)
            {
                throw new Exception("Employee does not have any services");
            }
        }
    }
}