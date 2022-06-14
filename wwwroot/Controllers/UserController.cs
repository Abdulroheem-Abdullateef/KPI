using KpiNew.Auth;
using KpiNew.Dto;
using KpiNew.Interfaces.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;

        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestModel model)
        {
            var response = await _userService.AddUser(model);

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestModel model)
        {
            var response = await _userService.UpdateUser(id, model);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var respond = await _userService.DeleteUser(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }



        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var respond = await _userService.GetUserById(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var respond = await _userService.GetAllUser();
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);

        }


        [HttpGet("GetUserByEmail{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            var respond = await _userService.GetUserByEmail(email);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }

        [HttpPost("{Login}")]
        
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            var respond = await _userService.Login(model);
            if (respond.Success)
            {
                var token = _jwtAuthenticationManager.GenerateToken(respond.Data);
                var login = new LoginRespondeModel
                {
                    Data = respond.Data,
                    Token = token
                };
                return Ok(login);
                
            }
            return BadRequest(respond);

        }



    }
}
