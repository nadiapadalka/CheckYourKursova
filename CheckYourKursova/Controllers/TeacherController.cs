// <copyright file="TeacherController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AuthApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.Hubs;
    using Kursova.Models;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly ILogger<TeacherController> stlogger;
        private readonly KursovaDbContext db;
        private readonly IWebHostEnvironment _appEnvironment;
        private CourseProjects projects = new CourseProjects();
        private readonly IHubContext<NotifyHub> _hubContext;

        public TeacherController(KursovaDbContext kursovadb, ITeacherService iteacherservice, ILogger<TeacherController> logger, IWebHostEnvironment buidler, IHubContext<NotifyHub> hubContext)
        {
            this.db = kursovadb;
            this.teacherService = iteacherservice;
            this.stlogger = logger;
            this._appEnvironment = buidler;
            _hubContext = hubContext;
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
                Teacher result = await this.teacherService.Get(model.Email, model.Password);
              //  Teacher user = await db.Teachers.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (result != null)
                {
                    await this.Authenticate(model.Email);

                    this.stlogger.LogInformation($"Teacher Loginned successfully ");

                  //  this.Folder(result.Initials, "Create");

                    return this.RedirectToAction("Teacher_home", "Admin");
                }
                return this.RedirectToAction("LoginTeacher", "Teacher");
            }

            return this.View(model);
        }

        private void Folder(string ownerName, string option = "Create")
        {
            DirectoryInfo dir = Directory.CreateDirectory("..\\CheckYourKursova\\wwwroot\\Users\\" + ownerName);
            Directory.CreateDirectory("..\\CheckYourKursova\\wwwroot\\Users\\" + ownerName + "\\Downloaded files");
            Directory.CreateDirectory("..\\CheckYourKursova\\wwwroot\\Users\\" + ownerName + "\\Uploaded files");
            if (option == "Delete")
            {
                dir.Delete();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(string email, KursovaPageModel model)
        {
            if (this.ModelState.IsValid)
            {
                Teacher user = await this.teacherService.GetbyEmail(email);
                this.stlogger.LogInformation("Student in comment controller found!");
                if (user != null)
                {
                    this.db.Add(new Comment { Initials = user.Initials, CourseWork = user.Grade, Description = model.Comment });
                    this.db.SaveChanges();
                    this.stlogger.LogInformation("Comment added successfully ");

                    return this.RedirectToAction("Student_Kursova", "Student");
                }
                else
                {
                    this.stlogger.LogInformation("Student do not exist!  ");
                }
            }

            return this.View(model);
        }

        public async Task<IActionResult> Teacher_Kursova()
        {
            return this.View(this.projects);
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
                    await TSendMessage(" Зареструвався новий викладач.");
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
            return this.View();
        }

        [HttpGet]
        public FileResult GetFile(string filename, string ownerName)
        {
            // string path = Path.Combine(this._appEnvironment.ContentRootPath, "wwwroot/files/" + filename);

            string path = $"..\\CheckYourKursova\\wwwroot\\Users\\{ownerName}\\Downloaded files\\{filename}";
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string fileType = this.GetFileType(filename);
            return this.File(mas, fileType, filename);
        }

        private string GetFileType(string filename)
        {
            var type = filename.Split(".")[1];

            using (StreamReader stream = new StreamReader("..\\CheckYourKursova\\wwwroot\\files\\application.txt"))
            {
                var types = stream.ReadToEnd().Split(" ");
                foreach (var item in types)
                {
                    if (item == "vnd.openxmlformats-officedocument.wordprocessingml.document" && type == "docx")
                    {
                        return "application/" + item;
                    }
                    else if (item == "vnd.openxmlformats-officedocument.spreadsheetml.sheet" && type == "xlsx")
                    {
                        return "application/" + item;
                    }
                    else if (item == "vnd.openxmlformats-officedocument.presentationml.presentation" && type == "pptx")
                    {
                        return "application/" + item;
                    }

                    if (item == type)
                    {
                        return "application/" + item;
                    }
                }
            }

            using (StreamReader stream = new StreamReader("..\\CheckYourKursova\\wwwroot\\files\\text.txt"))
            {
                var types = stream.ReadToEnd().Split(" ");
                foreach (var item in types)
                {
                    if (item == type)
                    {
                        return "text/" + item;
                    }
                }
            }

            using (StreamReader stream = new StreamReader("..\\CheckYourKursova\\wwwroot\\files\\image.txt"))
            {
                var types = stream.ReadToEnd().Split(" ");
                foreach (var item in types)
                {
                    if (item == type)
                    {
                        return "image/" + item;
                    }
                }
            }

            return null;
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file, string ownerName)
        {
            string filename = string.Empty;
            foreach (var item in file.FileName.Split("\\"))
            {
                filename = item;
            }

            string path = $"..\\CheckYourKursova\\wwwroot\\Users\\{ownerName}\\Uploaded files\\{filename}";

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                file.CopyTo(stream);
                this.projects.AllProjects[0].TeacherMaterials.Add(filename);
            }
            var doc = this.db.Documentations.Where(doc => doc.TeacherName == ownerName).LastOrDefault();
            if (doc != null)
            {
                doc.AttachedTeacherMaterials += filename + "/";
                this.db.Documentations.Update(doc);
            }
            return this.RedirectToAction("Teacher_Kursova");
        }

        [HttpPost]
        public async Task TSendMessage(string message)
        {
            await this._hubContext.Clients.All.SendAsync("TSend", message);
        }
    }
}

