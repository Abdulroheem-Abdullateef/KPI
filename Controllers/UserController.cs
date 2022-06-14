using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KpiNew.Dtos;
using KpiNew.Interface.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace KpiNew.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;  

        public UserController(IUserService userService, IDepartmentService departmentService,IEmployeeService employeeService )
        {
            _userService = userService;
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

          public async Task<IActionResult> Index()
        {
            var user = await _userService.GetAllUserAsync();
            if (user == null)
            {
                return NotFound();
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user.Data == null)
            {
                return ViewBag.Message("User not found");
            }
            return View(user.Data);
        }


      


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            var user = await _userService.Login(model);
            if (user.Data != null)
            {
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Email, user.Data.Email),
                   new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
                   new Claim("Department", user.Data.Department)                

                };
                foreach (var role in user.Data.Roles)
                {

                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                
                return RedirectToAction("Index", "Employee");
            }

            else
            {
                ViewBag.error = "Invalid username or password";
                return View();
            }

        }

    }
}