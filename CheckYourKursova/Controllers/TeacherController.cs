// <copyright file="TeacherController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AuthApp.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly ILogger<TeacherController> stlogger;
        private readonly KursovaDbContext db;

        public TeacherController(KursovaDbContext kursovadb, ITeacherService iteacherservice, ILogger<TeacherController> logger)
        {
            this.db = kursovadb;
            this.teacherService = iteacherservice;
            this.stlogger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult LoginTeacher()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginTeacher(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.teacherService.Get(model.Email, model.Password);

                if (result != null)
                {
                    await this.Authenticate(model.Email);

                    this.stlogger.LogInformation($"Teacher Loginned successfully ");

                    return this.RedirectToAction("Teacher_home", "Teacher");
                }

                this.ModelState.AddModelError(string.Empty, "Некорректний логін і(або) пароль");
            }

            return this.View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Teacher_Kursova()
        {
            return this.View(await this.teacherService.GetAll());
        }

        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.teacherService.Get(model.Email, model.Initials);
                if (result == null)
                {
                   this.db.Add(
                   new Teacher { Email = model.Email, Password = model.Password, Initials = model.Initials, Grade = model.Grade, Kafedra = model.Kafedra });
                   await this.Authenticate(model.Email);
                   this.stlogger.LogInformation($"Teacher Loginned successfully ");
                   this.db.SaveChanges();
                   return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Некоректний логін і(чи) пароль");
                }
            }

            return this.View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Teacher_home()
        {
            this.stlogger.LogInformation($"Teacher Info page ");

            return this.View(await this.teacherService.GetAll());
        }

        [HttpGet]
        public IActionResult ChangeTeacherPassword()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeTeacherPassword(ChangeTeacherPasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                Teacher user = await this.teacherService.Get(model.Email, model.Initials);
                if (user != null)
                {
                    user.Password = model.Password;
                    this.teacherService.Update(user);
                    await this.Authenticate(model.Email);
                    this.stlogger.LogInformation($"Teacher password changed ");

                    return this.RedirectToAction("Index", "Home");
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTask(CreateTaskModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.db.TaskItems.Add(
                new TaskItem
                {
                    Title = model.Title,
                    Description = model.Description,
                    Grade = model.Grade,
                    StartDate = model.StartDate,
                    DeadLine = model.DeadLine,
                    EstimatedTime = model.EstimatedTime,
                    IsDone = model.IsDone,
                });
                await this.db.SaveChangesAsync();

                return this.RedirectToAction("Account");
            }

            return this.View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.RedirectToAction("Login", "Account");
        }
        public IActionResult Teacher_notification()
        {
            return View();
        }
    }

}