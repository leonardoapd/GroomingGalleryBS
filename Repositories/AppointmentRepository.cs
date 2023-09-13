using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingGalleryBs.Data;
using GroomingGalleryBs.Models;
using Microsoft.EntityFrameworkCore;

namespace GroomingGalleryBs.Repositories
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly AppDBContext _context;

        public AppointmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public Task<Appointment> Create(Appointment Appointment)
        {
            try
            {
                _context.Appointments.Add(Appointment);
                _context.SaveChanges();
                return Task.FromResult(Appointment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(Guid id)
        {
            try
            {
                var Appointment = _context.Appointments.FirstOrDefault(c => c.Id == id);

                if (Appointment != null)
                {
                    _context.Appointments.Remove(Appointment);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Appointment>> GetAll()
        {
            try
            {
                var Appointments = _context.Appointments
                    .Include(a => a.Employee)
                    .ThenInclude(e => e!.EmployeeServices!)
                    .ThenInclude(es => es.Service)
                    .Include(a => a.Service)
                    .Include(a => a.Customer)
                    .ToList() ?? new List<Appointment>();

                return Task.FromResult(Appointments.AsEnumerable());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Appointment> GetById(Guid id)
        {
            try
            {
                var Appointment = await _context.Appointments
                    .Include(a => a.Employee)
                    .ThenInclude(e => e!.EmployeeServices!)
                    .ThenInclude(es => es.Service)
                    .Include(a => a.Service)
                    .Include(a => a.Customer)
                    .FirstOrDefaultAsync(c => c.Id == id) ?? new Appointment();

                return Appointment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Update(Appointment Appointment)
        {
            try
            {
                var existingCppointment = _context.Appointments.FirstOrDefault(c => c.Id == Appointment.Id);

                if (existingCppointment != null)
                {
                    _context.Entry(existingCppointment).State = EntityState.Detached;
                    _context.Appointments.Update(Appointment);
                    _context.SaveChanges();
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}