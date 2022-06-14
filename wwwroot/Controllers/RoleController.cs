using KpiNew.Dto;
using KpiNew.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
          
        
            [HttpPost("CreateRole")]
            public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestModel model)
            {
                var response = await _roleService.AddRole(model);

                if (response.Success) return Ok(response);
                return BadRequest(response);
            }

            [HttpPost("UpdateRole/{id}")]
            public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] UpdateRoleRequestModel model)
            {
                var response = await _roleService.UpdateRole(id, model);
                if (response.Success) return Ok(response);
                return BadRequest(response);
            }

            [HttpDelete("Delete/{id}")]
            public async Task<IActionResult> DeleteRole([FromRoute] int id)
            {
                var respond = await _roleService.DeleteRole(id);
                if (respond.Success) return Ok(respond);
                return BadRequest(respond);
            }



            [HttpGet("GetRoleById/{id}")]
            public async Task<IActionResult> GetRoleById([FromRoute] int id)
            {
                var respond = await _roleService.GetRoleById(id);
                if (respond.Success) return Ok(respond);
                return BadRequest(respond);
            }


            [HttpGet("GetAllRole")]
            public async Task<IActionResult> GetAllRole()
            {
                var respond = await _roleService.GetAllRole();
                if (respond.Success) return Ok(respond);
                return BadRequest(respond);

            }


        

    }
}   

