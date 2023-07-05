using AngularBigbang.Models.DTO;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;

namespace AngularBigBang.Interfaces
{
    public interface IDoctor
    {
        Task<Doctor> Add(Doctor doctor);
        Task<Doctor> Update(Doctor doctor);
        Doctor Delete(DoctorDTO doctorDTO);
        Task<Doctor> Get(DoctorDTO doctorDTO);
        Task<List<Doctor>?> GetAll();
    }
}
