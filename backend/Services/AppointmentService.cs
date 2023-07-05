using AngularBigBang.Interfaces;
using AngularBigBang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularBigBang.Services
{
  public class AppointmentService : IAppointmentService
  {

    private readonly AngularBigBangContext _context;

    public AppointmentService(AngularBigBangContext context)
    {
      _context = context;
    }

    public async Task<List<Appointment>> GetAppointments()
    {
      var appointments =  await _context.Appointments.ToListAsync();
      return appointments;
    }

    public async Task<Appointment> GetAppointment(int id)
    {

      var appointment = await _context.Appointments.FindAsync(id);
      return appointment;
    }



    public async Task<List<Appointment>> PatientAppointment(string puser)
    {
      var patientAppointments = await _context.Appointments
    .Where(a => a.Pusername == puser)
    .ToListAsync();
      return patientAppointments;
    }

    public async Task<List<Appointment>> DoctorAppointment(string duser)
    {
      var doctorAppointments = await _context.Appointments
    .Where(a => a.Dusername == duser)
    .ToListAsync();
      return doctorAppointments;
    }



    public async Task<Appointment> PutAppointment(int id, Appointment appointment)
    {
      var clients = await _context.Appointments.FindAsync(id);

      clients.Pusername = appointment.Pusername;
      clients.Dusername = appointment.Dusername;
      clients.Age = appointment.Age;
      clients.Date = appointment.Date;
      await _context.SaveChangesAsync();
      return clients;
    }


    public async Task<List<Appointment>> PostAppointment(Appointment appointment)
    {

      _context.Appointments.Add(appointment);
      await _context.SaveChangesAsync();
      return await _context.Appointments.ToListAsync();

    }



    public async Task<List<Appointment>> DeleteAppointment(int id)
    {

      var appointment = await _context.Appointments.FindAsync(id);
      

      _context.Appointments.Remove(appointment);
      await _context.SaveChangesAsync();
      return await _context.Appointments.ToListAsync();
    }


   public async Task<List<Doctor>> GetAllAppointments()
    {
      var appointments = await _context.Doctors.ToListAsync();
      return appointments;
    }
  
  }
}
