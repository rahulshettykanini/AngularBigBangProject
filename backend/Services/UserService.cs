﻿using AngularBigbang.Interfaces;
using AngularBigbang.Models.DTO;
using AngularBigbang.Models;
using System.Security.Cryptography;
using System.Text;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;

namespace AngularBigbang.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _userRepo;
        private readonly ITokenGenerate _tokenService;
        private static List<UserRegisterDTO> staffList = new List<UserRegisterDTO>();


        public UserService(IUser userRepo, ITokenGenerate tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
            
        }
        public async Task<UserDTO> LogIN(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userRepo.Get(userDTO);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.HashKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.UserName = userData.UserName;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO> Register(UserRegisterDTO userRegisterDTO)
        {
            UserDTO user = null;
            UserRegisterDTO userToDelete = staffList.Find(user => user.UserName == userRegisterDTO. UserName);
            if (userToDelete != null)
            {
                // Remove the object from the list
                staffList.Remove(userToDelete);
            }
            using (var hmac = new HMACSHA512())
            {
                userRegisterDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.UserPassword));
                userRegisterDTO.HashKey = hmac.Key;
                var resultUser = await _userRepo.Add(userRegisterDTO);
                if (resultUser != null)
                {
                    user = new UserDTO();
                    user.UserName = resultUser.UserName;
                    user.Role = resultUser.Role;
                    user.Token = _tokenService.GenerateToken(user);
                }
            }
            return user;
        }

        public async Task<UserRegisterDTO?> staffRegister(UserRegisterDTO userRegisterDTO,StaffDTO staffDTO)
        {
            var users = await _userRepo.GetAll();
            var newstaff = users.SingleOrDefault(u => u.UserName == userRegisterDTO.UserName);
            UserRegisterDTO desiredUser = staffList.SingleOrDefault(u => u.UserName == userRegisterDTO.UserName);
            if (newstaff == null && desiredUser==null) 
            {
                
                /* UserRegisterDTO user1 = new UserRegisterDTO();
                 user1.Name = userRegisterDTO.Name;
                 user1.EmailId = userRegisterDTO.EmailId;
                 user1.UserName = userRegisterDTO.UserName;
                 user1.PhoneNumber = userRegisterDTO.PhoneNumber;
                 user1.Address = userRegisterDTO.Address;
                 user1.Role = userRegisterDTO.Role;
                 user1.UserPassword = userRegisterDTO.UserPassword;*/
               
                    staffList.Add(userRegisterDTO);
/*                  staffDTO.get(staffDTO);
*/




                return userRegisterDTO;
            }


            return null; 

        }
        public  async Task<UserRegisterDTO?> deletestaffinlist(UserRegisterDTO userRegisterDTO)
        {
            UserRegisterDTO userToDelete = staffList.Find(user => user.UserName == userRegisterDTO.UserName);
            if (userToDelete != null)
            {
                // Remove the object from the list
                staffList.Remove(userToDelete);
                return userRegisterDTO;
            }
            return null;
        }

        public async Task<List<UserRegisterDTO>> View_All_StaffRequest(StaffDTO staffDTO)
        {
            /*var obj = staffDTO.GetStaffList();
            List<UserRegisterDTO> retrievedList = obj.staffList;
            if (retrievedList == null)
            {
                return null;
            }
            return retrievedList;*/

            if(staffList==null)
            {
                return null;
            }
            return staffList;


        }



        public async Task<UserDTO> Update(UserRegisterDTO user)
        {
            var users = await _userRepo.GetAll();
            User myUser = users.SingleOrDefault(u => u.UserName == user.UserName);
            if (myUser != null)
            {
                myUser.Name = user.Name;
                myUser.Gender = user.Gender;
                var hmac = new HMACSHA512();
                myUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                myUser.HashKey = hmac.Key;
                myUser.Role = user.Role;
                myUser.Email = user.Email;
                UserDTO userDTO = new UserDTO();
                userDTO.UserName = myUser.UserName;
                userDTO.Role = myUser.Role;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                var newUser = _userRepo.Update(myUser);
                if (newUser != null)
                {
                    return userDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> Update_Password(UserDTO userDTO)
        {
            User user = new User();
            var users = await _userRepo.GetAll();
            var myUser = users.SingleOrDefault(u => u.UserName == userDTO.UserName);
            if (myUser != null)
            {
                var hmac = new HMACSHA512();
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                user.HashKey = hmac.Key;
                user.Name = myUser.Name;
                user.Role = myUser.Role;
                user.Gender = myUser.Gender;
                user.Email = myUser.Email;
                var newUser = _userRepo.Update(user);
                if (newUser != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
