using KpiNew.Dto;
using KpiNew.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpPost("CreateAdmin")]

        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminRequestModel model)
        {
            var response = await _adminService.AddAdmin(model);

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("UpdateAdmin/{id}")]
        public async Task<IActionResult> UpdateAdmin([FromRoute] int id, [FromBody] UpdateAdminRequestModel model)
        {
            var response = await _adminService.UpdateAdmin(id, model);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAdmin([FromBody] int id)
        {
            var respond = await _adminService.DeleteAdmin(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetAdminById/{id}")]
        public async Task<IActionResult> GetAdminById([FromRoute] int id)
        {
            var respond = await _adminService.GetAdminById(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }

        [HttpGet("GetAllAdmin")]
        public async Task<IActionResult> GetAllAdmin()
        {
            var respond = await _adminService.GetAllAdmin();
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);

        }

    }
}
