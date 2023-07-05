using AngularBigBang.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularBigBang.Interfaces
{
  public interface IAppointmentService
  {

    public  Task<List<Appointment>> GetAppointments();

    public  Task<Appointment> GetAppointment(int id);


    public Task<List<Appointment>> PatientAppointment(string puser);
    public Task<List<Appointment>> DoctorAppointment(string duser);

    public Task<Appointment> PutAppointment(int id, Appointment appointment);


    public Task<List<Appointment>> PostAppointment(Appointment appointment);



    public Task<List<Appointment>> DeleteAppointment(int id);


    public  Task<List<Doctor>> GetAllAppointments();
  }
}
