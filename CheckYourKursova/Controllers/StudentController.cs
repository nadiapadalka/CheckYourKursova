using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Kursova.DAL.Entities;
using Kursova.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kursova.DAL.EF;
using Kursova.BLL.Services;
using Kursova.BLL.Interfaces;
using Microsoft.Extensions.Logging;


namespace Kursova.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly KursovaDbContext db;
        public StudentController(KursovaDbContext _db, IStudentService studentService, ILogger<StudentController> logger)
        {
            db = _db;
            _studentService = studentService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
              
                var result =  _studentService.Get(model.Email, model.Password);
                if (result != null)
                {
                    await Authenticate(model.Email);
                    _logger.LogInformation($"Student loginned successfully ");

                    return RedirectToAction("Student_home", "Student");
                }
                ModelState.AddModelError("", "Некорректний логін і(або) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            
            if (ModelState.IsValid)

            {
                var user = await _studentService.GetbyEmail(model.Email);
                if (user == null)
                {

                    // _studentService.CreateStudent(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
                    db.Add(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
                     await Authenticate(model.Email);
                    _logger.LogInformation("Student registered successfully ");

                    return RedirectToAction("Index", "Home");
                }
                else
                   // ModelState.AddModelError("", "Некоректний логін і(чи) пароль");
                { _logger.LogInformation("Student exists!  "); }

            }
            return View(model);
        }
        [HttpGet]

        public  async Task<IActionResult> Student_home()
        {
            _logger.LogInformation("Getting info about student");
            return View(await _studentService.GetAll());
        }
        [HttpGet]

        public  IActionResult Student_Kursova()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                Student user = await _studentService.Get(model.Email, model.FullName);
                if (user != null)
                {
                    user.Password = model.Password;
                    _studentService.Update(user);
                    await Authenticate(model.Email);
                    return RedirectToAction("Index", "Home");
                }
                _logger.LogInformation("Student password changed");
                return RedirectToAction("Login", "Student");

            }
            return View(model);
        }
       
    }
}