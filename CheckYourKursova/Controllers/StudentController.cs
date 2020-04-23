// <copyright file="StudentController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> log;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IStudentService service;
        private readonly KursovaDbContext db;
        private CourseStudentProjects projects = new CourseStudentProjects();


        public StudentController(KursovaDbContext database, IStudentService studentService, ILogger<StudentController> logger, IWebHostEnvironment builder)
        {
            this.db = database;
            this.service = studentService;
            this.log = logger;
            this._appEnvironment = builder;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.service.Get(model.Email, model.Password);
                if (result != null)
                {
                    await this.Authenticate(model.Email);
                    this.log.LogInformation($"Student loginned successfully ");

                    return this.RedirectToAction("Student_home", "Student");
                }

                this.ModelState.AddModelError(string.Empty, "Некорректний логін і(або) пароль");
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

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.service.GetbyEmail(model.Email);
                if (user == null)
                {
                    // _studentService.CreateStudent(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
                    this.db.Add(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
                    await this.Authenticate(model.Email);
                    this.db.SaveChanges();
                    this.log.LogInformation("Student registered successfully ");

                    return this.RedirectToAction("Student", "Student_home");
                }
                else
                {
                    this.log.LogInformation("Student exists!  ");
                }
            }

            return this.View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Student_home()
        {
            this.log.LogInformation("Getting info about student");
            return this.View(await this.service.GetAll());
        }

        [HttpGet]

        public IActionResult Student_Kursova()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                Student user = await this.service.Get(model.Email, model.FullName);
                if (user != null)
                {
                    user.Password = model.Password;
                    this.service.Update(user);
                    await this.Authenticate(model.Email);
                    return this.RedirectToAction("Index", "Home");
                }

                this.log.LogInformation("Student password changed");
                return this.RedirectToAction("Login", "Student");
            }

            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public FileResult GetFile(string filename)
        {
            string path = Path.Combine(this._appEnvironment.ContentRootPath, "wwwroot/files/" + filename);
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
        public IActionResult UploadFile(IFormFile file)
        {
            string filename = string.Empty;
            foreach (var item in file.FileName.Split("\\"))
            {
                filename = item;
            }

            using (FileStream stream = new FileStream("..\\CheckYourKursova\\wwwroot\\files\\uploadedfiles\\" + filename, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
                this.projects.AllProjects[0].StudentMaterials.Add(filename);
            }

            return this.RedirectToAction("Student_Kursova");
        }
    }
}