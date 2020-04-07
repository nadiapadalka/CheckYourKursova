using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kursova.BLL.DTO;
using Kursova.DAL.Entities;
using Kursova.BLL.Interfaces;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Kursova.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace Kursova.Controllers
{
    public class AdminController : Controller
    {
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IAdminService adminService;
        private KursovaDbContext db;
        public AdminController(KursovaDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UsersInfoModel info = new UsersInfoModel();
            info.Students = db.Students;
            info.Teachers = db.Teachers;
            return View(info);
        }
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAdmin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Admin user = await db.Admins.FirstOrDefaultAsync(u => u.Name == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Admin");
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

    }
}