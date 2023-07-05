using AngularBigbang.Exeptions;
using AngularBigbang.Models.DTO;
using AngularBigBang.Interfaces;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AngularBigBang.Services
{
    public class DoctorRepo:IDoctor
    {
        private readonly AngularBigBangContext _context;

        public DoctorRepo(AngularBigBangContext context)
        {
            _context = context;
        }
        public async Task<Doctor?> Add(Doctor doctor)
        {
            try
            {
                var Doctors = _context.Doctors;
                var myDoctor = await Doctors.SingleOrDefaultAsync(u => u.UserName == doctor.UserName);
                if (myDoctor == null)
                {
                    await _context.Doctors.AddAsync(doctor);
                    await _context.SaveChangesAsync();
                    return doctor;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public Doctor? Delete(DoctorDTO doctorDTO)
        {
            try
            {
                var Doctors = _context.Doctors;
                var myDoctor = Doctors.SingleOrDefault(u => u.UserName == doctorDTO.UserName);
                if (myDoctor != null)
                {
                    _context.Doctors.Remove(myDoctor);
                    _context.SaveChanges();
                    return myDoctor;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<Doctor?> Get(DoctorDTO doctorDTO)
        {
            try
            {
                var Doctors = await GetAll();
                var Doctor = Doctors.FirstOrDefault(u => u.UserName == doctorDTO.UserName);
                if (Doctor != null)
                {
                    return Doctor;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<List<Doctor>?> GetAll()
        {
            try
            {
                var Doctors = await _context.Doctors.ToListAsync();
                if (Doctors != null)
                    return Doctors;
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<Doctor> Update(Doctor doctor)
        {
            try
            {
                var Doctors = await GetAll();
                var NewDoctor = Doctors.FirstOrDefault(u => u.UserName == doctor.UserName);
                if (NewDoctor != null)
                {
                    _context.Doctors.Update(NewDoctor);
                    await _context.SaveChangesAsync();
                    return NewDoctor;
                }
                else
                    return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }
    }
}
