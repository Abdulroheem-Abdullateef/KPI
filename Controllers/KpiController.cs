using KpiNew.Dtos;
using KpiNew.Interface;
using KpiNew.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{
    public class KpiController : Controller
    {
        private readonly IKpiService _kpiService;
        private readonly IDepartmentService _departmentService;

        public KpiController(IKpiService kpiService, IDepartmentService departmentService)
        {
            _kpiService = kpiService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var kpi = await _kpiService.GetAllKpiAsync();
            return View(kpi.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var department = await _departmentService.GetAllDepartmentAsync();
            ViewData["Departments"] = new SelectList(department.Data, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKpiRequestModel model)
        {   
             await _kpiService.AddKpiAsync(model);
             return RedirectToAction("Index");

        }

        
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var kpi = await _kpiService.GetKpiByIdAsync(id);
            if (kpi.Data == null)
            {
                return NotFound();
            }
            return View(kpi.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var kpi = await _kpiService.GetKpiByIdAsync(id);
            if (kpi == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateKpiRequestModel model)
        {
            await _kpiService.UpdateKpiAsync(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {

            var kpi = await _kpiService.GetKpiByIdAsync(id);
            if (kpi == null)
            {
                return NotFound();
            }
            return View(kpi.Data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _kpiService.DeleteKpiAsync(id);
            return RedirectToAction("Index");
        }











    }
}