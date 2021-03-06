﻿// <copyright file="TeacherController.cs" company="PlaceholderCompany">
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
        

        public TeacherController(KursovaDbContext kursovadb, ITeacherService iteacherservice, ILogger<TeacherController> logger, IWebHostEnvironment buidler)
        {
            this.db = kursovadb;
            this.teacherService = iteacherservice;
            this.stlogger = logger;
            this._appEnvironment = buidler;
           
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

                if (result != null)
                {
                    await this.Authenticate(model.Email);

                    this.stlogger.LogInformation($"Teacher Loginned successfully ");

                    this.Folder(result.Initials, "Create");

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
                Teacher user = await this.teacherService.GetbyEmail(model.Email);
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

        public async Task<IActionResult> LogOut()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            this.stlogger.LogInformation("Teacher LogOut");
            return this.RedirectToAction("Index", "Home");
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

        public IActionResult Teacher_notification()
        {
            return this.View();
        }

        [HttpGet]
        public FileResult GetFile(string filename, string ownerName)
        {
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
        public async Task<IActionResult > UploadFile(string email, IFormFile file, string ownerName)
        {
            string filename = string.Empty;
            Teacher teacher = await this.teacherService.GetbyEmail(ownerName);

            foreach (var item in file.FileName.Split("\\"))
            {
                filename = item;
            }

            string filepath = System.IO.Path.GetFileName(file.FileName);
            string path = $"..\\CheckYourKursova\\wwwroot\\Users\\{teacher.Initials}\\Uploaded files\\{filepath}";
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                file.CopyTo(stream);
            }
            this.db.Documentations.Add(
                    new Documentation {  TeacherName = teacher.Initials, Title = filepath });
            this.db.SaveChanges();
            return this.RedirectToAction("Teacher_Kursova");
        }

    }
}