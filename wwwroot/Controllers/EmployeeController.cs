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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IKpiService _kpiService;
        public EmployeeController(IEmployeeService employeeService, IKpiService kpiService)
        {
            _employeeService = employeeService;
            _kpiService = kpiService;

        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequestModel model)
        {
            var response = await _employeeService.AddEmployee(model);

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeRequestModel model)
        {
            var response = await _employeeService.UpdateEmployee(id, model);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var respond = await _employeeService.DeleteEmployee(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }



        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var respond = await _employeeService.GetEmployeeById(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var respond = await _employeeService.GetAllEmployee();
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);

        }

        [HttpPost("GetEmployeePerformanceRating")]
        public async Task<IActionResult> GetEmployeePerformanceRating([FromRoute] int id, [FromBody] EmployeeRatingPerformance model)
        {
            var respond = await _employeeService.CalculateEmployeePerformance(id, model);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }

        [HttpPost("GetEmployeeRating")]
        public async Task<IActionResult> GetEmployeeRating([FromBody] RatingPerformance model)
        {
            var respond = await _employeeService.Performance( model);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetEmployeeByDepartmentId/{id}")]
        public async Task<IActionResult> GetEmployeeByDepartment([FromRoute] int departmentId)
        {
            var respond = await _employeeService.GetEmployeeByDepartment(departmentId);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetEmployeeByDepartmentEmail/{id}")]
        public async Task<IActionResult> GetEmployeeByDepartmentName([FromRoute] string email)
        {
            var respond = await _employeeService.GetEmployeeByName(email);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }

    }
}
