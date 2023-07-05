using AngularBigbang.Models.DTO;
using AngularBigBang.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AngularBigbang.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Register(UserRegisterDTO userRegisterDTO);
        Task<UserDTO> LogIN(UserDTO userDTO);
        Task<UserDTO> Update(UserRegisterDTO user);
        Task<bool> Update_Password(UserDTO userRegisterDTO);

        Task<UserRegisterDTO?> staffRegister(UserRegisterDTO userRegisterDTO,StaffDTO staffDTO);

        Task<List<UserRegisterDTO>> View_All_StaffRequest(StaffDTO staffDTO);
        Task<UserRegisterDTO?> deletestaffinlist(UserRegisterDTO userRegisterDTO);


    }
}
