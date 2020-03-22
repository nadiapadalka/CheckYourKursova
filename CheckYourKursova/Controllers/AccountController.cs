﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Kursova.DAL.Entities;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kursova.DAL.EF;

namespace AuthApp.Controllers
{
    public class AccountController : Controller
    {
        private KursovaDbContext db;
        public AccountController(KursovaDbContext context)
        {
            db = context;
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
                //var result = db.Students.Join(db.Teachers, x => new { x.Email, x.Password },
                //     y => new { y.Email, y.Password }, (x, y) => x);
                Student user = await db.Students.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); 

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректний логін і(або) пароль");
            }
            return View(model);
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
                Teacher user = await db.Teachers.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректний логін і(або) пароль");
            }
            return View(model);
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
                Student user = await db.Students.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    db.Students.Add(new Student { Email = model.Email, Password = model.Password, Surname = model.Surname, Name = model.Name, Group = model.Group, Kafedra = model.Kafedra });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некоректний логін і(чи) пароль");
            }
            return View(model);
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
                Teacher teacher = await db.Teachers.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (teacher == null)
                {
                    db.Teachers.Add(new Teacher { Email = model.Email, Password = model.Password, Initials = model.Initials, Grade = model.Grade, Kafedra = model.Kafedra });
                    await db.SaveChangesAsync();
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некоректний логін і(чи) пароль");
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