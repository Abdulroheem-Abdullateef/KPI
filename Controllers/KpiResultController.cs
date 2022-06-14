using KpiNew.Dtos;
using System;
using KpiNew.Interface;
using KpiNew.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KpiNew.Enum;
using System.Security.Claims;
using System.Linq;

namespace KpiNew.Controllers
{
    public class KpiResultController : Controller
    {
        private readonly IKpiResultService _kpiResultService;
        private readonly IEmployeeService _employeeService;
        private readonly IKpiService _kpiService;
        private readonly IDepartmentService _departmentService;
        public KpiResultController( IKpiResultService kpiResultService, IEmployeeService employeeService,IKpiService kpiService,
            IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _kpiResultService = kpiResultService;
            _kpiService = kpiService;
            _departmentService = departmentService; 
        }

        public async Task<IActionResult> Index()
        {
            var kpiResult = await _kpiResultService.GetAllKpiResultAsync();
            return View(kpiResult.Data);
        }   

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //string dept = User.FindFirstValue("Department");
            var department = await _departmentService.GetDepartmentByName("Security");
            return View(department.Data.Kpis);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateKpiResultRequestModel model, int id)
        {
            var perce = 0.0;
            var month = DateTime.Now.Month;
            var kpi = HttpContext.Request.Form.Keys.ToList();

            for (int j = 0; j < kpi.Count-1; j++)
            {
                var e = kpi[j];
                var r = HttpContext.Request.Form[kpi[j]];
                var result = new CreateKpiFormResultRequestModel
                {
                    KpiId = int.Parse(e),
                    Percentage = int.Parse(r),
                };
                perce += result.Percentage;
                model.KpiForms.Add(result);
                //if (j == kpi.Count - 2)
                //{
                //    break;
                //}
            }
            model.DateCreated = DateTime.Now;
            model.TotalPercentage = perce;
            perce = 0.0;
            model.Year = DateTime.Now.Year;
            model.EmployeeId = id;

            switch (month)
            {
                case 1:
                    model.Month = Month.January;
                    break;
                case 2:
                    model.Month = Month.February;
                    break;
                case 3:
                    model.Month = Month.March;
                    break;
                case 4:
                    model.Month = Month.April;
                    break;
                case 5:
                    model.Month = Month.May;
                    break;
                case 6:
                    model.Month = Month.June;
                    break;
                case 7:
                    model.Month = Month.July;
                    break;
                case 8:
                    model.Month = Month.August ;
                    break;
                case 9:
                    model.Month = Month.September;
                    break;
                case 10:
                    model.Month = Month.October;
                    break;
                case 11:
                    model.Month = Month.November;
                    break;
                case 12:
                    model.Month = Month.December;
                    break;
                    
                default:
                    break;
            }



            await _kpiResultService.AddKpiResultAsync(model);
           return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var kpiResult = await _kpiResultService.GetKpiResultByIdAsync(id);
            if (kpiResult.Data == null)
            {
                return NotFound();
            }
            return View(kpiResult.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var kpiResult = await _kpiResultService.GetKpiResultByIdAsync(id);
            if (kpiResult == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateKpiResultRequestModel model)
        {
            await _kpiResultService.UpdateKpiResultAsync(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {

            var kpiResult = await _kpiResultService.GetKpiResultByIdAsync(id);
            if (kpiResult == null)
            {
                return NotFound();
            }
            return View(kpiResult.Data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _kpiResultService.DeleteKpiResultAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeKpiResultByYear(int employeeId, int year)
        {
            var kpiResultForYear = await _kpiResultService.GetEmployeeKpiResultByYearAsync(employeeId, year);
            return View(kpiResultForYear.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeKpiResultByMonth(int employeeId, Month month)
        {
            var kpiResultForMonth = await _kpiResultService.GetEmployeeKpiResultByMonthAsync(employeeId, month);
            return View(kpiResultForMonth.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeKpiResult(int employeeId)
        {
            var employeeKpiResult = await _kpiResultService.GetAllEmployeeKpiResultAsync(employeeId);
            return View(employeeKpiResult.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKpiResult()
        {
            var allKpiResult = await _kpiResultService.GetAllKpiResultAsync();
            return View(allKpiResult.Data);
        }
    }
}
