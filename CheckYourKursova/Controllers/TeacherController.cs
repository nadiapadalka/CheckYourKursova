using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Kursova.DAL.Entities;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kursova.DAL.EF;
using Kursova.BLL.Interfaces;
using Microsoft.Extensions.Logging;


namespace AuthApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly ILogger<TeacherController> _logger;
        private readonly KursovaDbContext db;

        public TeacherController(KursovaDbContext _db, ITeacherService _teacherservice, ILogger<TeacherController> logger)
        {
            db = _db;
            teacherService = _teacherservice;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginTeacher()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginTeacher(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = teacherService.Get(model.Email, model.Password);

                if (result != null)
                {
                    await Authenticate(model.Email);
                    
                        _logger.LogInformation($"Teacher Loginned successfully ");

                        return RedirectToAction("Teacher_home", "Teacher");
                }
                ModelState.AddModelError("", "Некорректний логін і(або) пароль");
            }
            return View(model);
        }

        
        [HttpGet]

        public async Task<IActionResult> Teacher_Kursova()
        {
            return View(await teacherService.GetAll());
        }

        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await teacherService.Get(model.Email, model.Initials);
                if (result == null)
                {
                     db.Add(
                   new Teacher { Email = model.Email, Password = model.Password, Initials = model.Initials, Grade = model.Grade, Kafedra = model.Kafedra });
                    await Authenticate(model.Email);
                    _logger.LogInformation($"Teacher Loginned successfully ");
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некоректний логін і(чи) пароль");
            }
            return View(model);
        }
        [HttpGet]

        public async Task<IActionResult> Teacher_home()
        {
            _logger.LogInformation($"Teacher Info page ");

            return View(await teacherService.GetAll());
        }
        [HttpGet]
        public IActionResult ChangeTeacherPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeTeacherPassword(ChangeTeacherPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                Teacher user = await teacherService.Get(model.Email, model.Initials);
                if (user != null)
                {
                    user.Password = model.Password;
                    teacherService.Update(user);
                    await Authenticate(model.Email);
                    _logger.LogInformation($"Teacher password changed ");

                    return RedirectToAction("Index", "Home");

                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTask(CreateTaskModel model)
        {
            if (ModelState.IsValid)
            {
                db.TaskItems.Add(
                new TaskItem
                {
                    Title = model.Title,
                    Description = model.Description,
                    Grade = model.Grade,
                    StartDate = model.StartDate,
                    DeadLine = model.DeadLine,
                    EstimatedTime = model.EstimatedTime,
                    IsDone = model.IsDone
                });
                await db.SaveChangesAsync();

                return RedirectToAction("Account");

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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}