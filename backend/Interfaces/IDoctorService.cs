using AngularBigbang.Models.DTO;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;

namespace AngularBigBang.Interfaces
{
    public interface IDoctorService
    {
        Task<UserDTO> Register(Doctor doctorRegisterDTO);

        Task<Doctor?> staffRegister(Doctor doctorRegisterDTO);

        Task<List<Doctor>> View_All_StaffRequest();
        Task<Doctor?> deletestaffinlist(Doctor doctorRegisterDTO);
    }
}
