using KpiNew.Dto;
using KpiNew.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class KpiController : ControllerBase
    {
        private readonly IKpiService _kpiService;
        public KpiController(IKpiService kpiService)
        {
            _kpiService = kpiService;
        }

        [HttpPost("CreateKpi")]
        public async Task<IActionResult> CreateKpi([FromBody] CreateKpiRequestModel model)
        {
            var response = await _kpiService.AddKpi(model);

            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("UpdateKpi/{id}")]
        public async Task<IActionResult> UpdateKpi([FromRoute] int id, [FromBody] UpdateKpiRequestModel model)
        {
            var response = await _kpiService.UpdateKpi(id, model);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteKpi([FromRoute] int id)
        {
            var respond = await _kpiService.DeleteKpi(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }



        [HttpGet("GetKpiById/{id}")]
        public async Task<IActionResult> GetKpiById([FromRoute] int id)
        {
            var respond = await _kpiService.GetKpiById(id);
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);
        }


        [HttpGet("GetAllKpi")]
        public async Task<IActionResult> GetAllKpi()
        {
            var respond = await _kpiService.GetAllKpi();
            if (respond.Success) return Ok(respond);
            return BadRequest(respond);

        }
    }
}
