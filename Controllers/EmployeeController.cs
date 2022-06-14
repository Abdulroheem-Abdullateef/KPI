using KpiNew.Dtos;
using KpiNew.Interface;
using KpiNew.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KpiNew.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IRoleService roleService,
         IUserService userService, IWebHostEnvironment webHostEnvironment, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _departmentService = departmentService;
        }
       
        public async Task<IActionResult> Index()
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserByIdAsync(id);
            foreach (var role in user.Data.Roles)
            {

                if (role.Name == "HOD")
                {

                    var department = User.FindFirstValue("Department");
                    var employee = await _employeeService.GetAllEmployeeDepartmentByNameAsync(department);
                    return View(employee.Data);
                }
                else if (role.Name == "Admin")
                {
                    var employee = await _employeeService.GetAllHodAsync();
                    return View(employee.Data);
                }
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var role = await _roleService.GetAllRoleAsync();
             ViewData["Role"] = new SelectList(role.Data, "Id", "Name");

            var department = await _departmentService.GetAllDepartmentAsync();
            ViewData["Departments"] = new SelectList(department.Data, "Id", "Name");

            return View();
        }

        [HttpPost]
         public async Task<IActionResult> Create(CreateEmployeeRequestModel model, IFormFile employeePhoto)
        {
            if (employeePhoto != null)
            {
                string employeePhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "employeePhotos");
                Directory.CreateDirectory(employeePhotoPath);
                string contentType = employeePhoto.ContentType.Split('/')[1];
                string employeeImage = $"AD{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(employeePhotoPath, employeeImage);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    employeePhoto.CopyTo(fileStream);
                }
                model.EmployeeImage = employeeImage;



            }

            await _employeeService.AddEmployeeAsync(model);
            return RedirectToAction("Index","Home");
         } 

        
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee.Data == null)
            {
                return NotFound();
            }
            return View(employee.Data);
        }

        [HttpGet]
        
        public async Task<IActionResult> Update(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateEmployeeRequestModel model)
        {
            await _employeeService.UpdateEmployeeAsync(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee.Data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeByDepartmentName()
        {
            var department = User.FindFirstValue("Department");
            var employee = await _employeeService.GetAllEmployeeDepartmentByNameAsync(department);
            return View(employee.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var employee = await _employeeService.GetAllEmployeeAsync();
            return View(employee.Data);
        }

    }
}