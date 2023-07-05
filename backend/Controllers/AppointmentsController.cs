using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBigBang.Models;
using AngularBigBang.Interfaces;

namespace AngularBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _iAppointmentService;


    public AppointmentsController(IAppointmentService iAppointmentService)
        {
            _iAppointmentService = iAppointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
      
      return await _iAppointmentService.GetAppointments();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
          
      return await _iAppointmentService.GetAppointment(id);
    }

    // GET: api/Appointments/pusername
    [HttpGet("patientname{puser}")]
    public async Task<ActionResult<Appointment>> PatientAppointment(string puser)
    {

      var patients = await _iAppointmentService.PatientAppointment(puser);
      return Ok(patients);
    }

    // GET: api/Appointments/dusername
    [HttpGet("doctorname{duser}")]
    public async Task<ActionResult<Appointment>> DoctorAppointment(string duser)
    {

      var doctors = await _iAppointmentService.DoctorAppointment(duser);
      return Ok(doctors);
    }

    // PUT: api/Appointments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
      var appointments = await _iAppointmentService.PutAppointment(id,appointment);
      return Ok(appointments);
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
          

      var appointments = await _iAppointmentService.PostAppointment(appointment);
      return Ok(appointments);
      
    }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            


      var appointments =  await _iAppointmentService.DeleteAppointment(id);
      return Ok(appointments);
    }

    [HttpGet("all")]
     public async Task<ActionResult<IEnumerable<Doctor>>> GetAllAppointments()
     {

       return await _iAppointmentService.GetAllAppointments();

     }

     
  }
}
