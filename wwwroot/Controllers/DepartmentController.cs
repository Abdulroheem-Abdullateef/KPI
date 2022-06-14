using KpiNew.Dto;
using KpiNew.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequestModel model)
        {
            var response = await _departmentService.AddDepartment(model);

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, [FromBody] UpdateDepartmentRequestModel model)
        {
            var response = await _departmentService.UpdateDepartment(id,model);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var respond = await _departmentService.DeleteDepartment(id);
            if (respond.Success) return Ok(respond); 
            return BadRequest(respond);
        }



        [HttpGet("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute]int id)
        {
            var respond = await _departmentService.GetDepartmentById(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var respond = await _departmentService.GetAllDepartment();
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);

        }
    }

    
}