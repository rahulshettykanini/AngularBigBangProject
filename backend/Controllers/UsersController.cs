using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBigbang.Models;
using AngularBigbang.Exeptions;
using AngularBigbang.Interfaces;
using AngularBigbang.Models.DTO;
using Microsoft.AspNetCore.Cors;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;

namespace AngularBigbang.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly StaffDTO _staffDTO;


        public UsersController(IUserService userService, StaffDTO staffDTO)
        {
            _userService = userService;
            _staffDTO = staffDTO;

        }
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                UserDTO user = await _userService.Register(userRegisterDTO);
                if (user == null)
                    return BadRequest(new Error(2, "Registration Not Successful"));
                return Created("User Registered", user);
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(3, ise.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(UserRegisterDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("staff")]
        public async Task<ActionResult<UserRegisterDTO?>> staffRegister(UserRegisterDTO userRegisterDTO)
        {

            var result = await _userService.staffRegister(userRegisterDTO, _staffDTO);
            return Ok(result);
        }

        [ProducesResponseType(typeof(UserRegisterDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("deleteStaffinlist")]
        public async Task<ActionResult<UserRegisterDTO?>> deletestaffinlist(UserRegisterDTO userRegisterDTO)
        {

            var result = await _userService.deletestaffinlist(userRegisterDTO);
            return Ok(result);
        }

        [ProducesResponseType(typeof(List<UserRegisterDTO>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<UserRegisterDTO>>> View_All_StaffRequest()
        {
            var result = await _userService.View_All_StaffRequest(_staffDTO);
            return Ok(result);

        }


        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LogIN(UserDTO userDTO)
        {
            try
            {
                UserDTO user = await _userService.LogIN(userDTO);
                if (user == null)
                    return BadRequest(new Error(1, "Invalid UserName or Password"));
                return Ok(user);
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(3, ise.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut("full Update")]
        public async Task<ActionResult<UserDTO>> Update(UserRegisterDTO user)
        {
            try
            {
                var myUser = await _userService.Update(user);
                if (myUser == null)
                    return NotFound(new Error(3, "Unable to Update"));
                return Created("User Updated Successfully", myUser);
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(3, ise.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut("password change")]
        public async Task<ActionResult<string>> Update_Password(UserDTO user)
        {
            try
            {
                bool myUser = await _userService.Update_Password(user);
                if (myUser)
                    return NotFound(new Error(3, "Unable to Update Password"));
                return Ok("Password Updated Successfully");
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(3, ise.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }
    }
}
