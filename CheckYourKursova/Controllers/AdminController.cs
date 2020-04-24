// <copyright file="AdminController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Repositories;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class AdminController : Controller
    {
        private KursovaDbContext db;
        private IAdminService service;
        private UsersInfoModel info = new UsersInfoModel();

        public AdminController(KursovaDbContext context, IAdminService service)
        {
            this.db = context;
            this.service = service;

            info.Students = this.service.GetAllStudents().Result.ToList();
            info.Teachers = this.service.GetAllTeachers().Result.ToList();
        }

        [HttpGet]
        public IActionResult LoginAdmin()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAdmin(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.service.GetAdmin(model.Email, model.Password);
                // var result = this.db.Admins.Where(admin => admin.Name == model.Email && admin.Password == model.Password).FirstOrDefault();
                if (result != null)
                {
                    await this.Authenticate(model.Email);
                    // this.log.LogInformation($"Admin loginned successfully ");

                    return this.RedirectToAction("Index", "Admin");
                }

                this.ModelState.AddModelError(string.Empty, "Некорректний логін і(або) пароль");
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            // info.Students = this.db.Students;
            // info.Teachers = this.db.Teachers;

            // info.Students = this.service.GetAllStudents().Result.ToList();
            // info.Teachers = this.service.GetAllTeachers().Result.ToList();

            return this.View(info);
        }

        [HttpGet]
        public IActionResult StudentDocuments(string email)
        {
            try
            {
                var studentId = this.db.Students.Where(x => x.Email == email).FirstOrDefault().Id;
                var documents = this.db.Documentations.Where(x => x.UserId == studentId).ToList();
                return this.View(documents);
            }
            catch
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult TeacherDocuments(string email)
        {
            try
            {
                var teacherId = this.db.Teachers.Where(x => x.Email == email).FirstOrDefault().Id;
                var documents = this.db.Documentations.Where(x => x.UserId == teacherId).ToList();
                return this.View(documents);
            }
            catch
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult DeleteStudent(string email)
        {
            var stud = this.db.Students.Where(x => x.Email == email).FirstOrDefault();
            if (stud != null)
            {
                this.db.Set<Student>().Remove(stud);
                this.db.SaveChanges();
            }
            // this.service.DeleteStudentByEmail(email);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTeacher(string email)
        {
            var teacher = this.db.Teachers.Where(x => x.Email == email).FirstOrDefault();
            if (teacher != null)
            {
                this.db.Set<Teacher>().Remove(teacher);
                this.db.SaveChanges();
            }
            // this.service.DeleteTeacherByEmail(email);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteStudentDocument(int id)
        {
            var document = this.db.Documentations.Where(doc => doc.Id == id).FirstOrDefault();
            if (document != null)
            {
                this.db.Set<Documentation>().Remove(document);
                this.db.SaveChanges();
            }

            return this.RedirectToAction("StudentDocuments");
        }

        [HttpPost]
        public IActionResult DeleteTeacherDocument(int id)
        {
            var document = this.db.Documentations.Where(doc => doc.Id == id).FirstOrDefault();
            if (document != null)
            {
                this.db.Set<Documentation>().Remove(document);
                this.db.SaveChanges();
            }

            return this.RedirectToAction("TeacherDocuments");
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                Student user = await this.db.Students.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    this.db.Students.Add(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
                    await this.db.SaveChangesAsync();

                    await this.Authenticate(model.Email);

                    return this.RedirectToAction("Index", "Admin");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Некоректний логін і(чи) пароль");
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return this.View("RegisterTeacher");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherModel model)
        {
            if (this.ModelState.IsValid)
            {
                Teacher teacher = await this.db.Teachers.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (teacher == null)
                {
                    this.db.Teachers.Add(
                    new Teacher { Email = model.Email, Password = model.Password, Initials = model.Initials, Grade = model.Grade, Kafedra = model.Kafedra });
                    await this.db.SaveChangesAsync();
                    await this.Authenticate(model.Email);

                    return this.RedirectToAction("Index", "Admin");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Некоректний логін і(чи) пароль");
                }
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

        [HttpPost]
        public IActionResult SetTeacherForStudent(string studentEmail, string teacherEmail)
        {
            var student = this.service.GetAllStudents().Result.ToList().Where(student => student.Email == studentEmail).FirstOrDefault();
            var teacher = this.service.GetAllTeachers().Result.ToList().Where(teacher => teacher.Email == teacherEmail).FirstOrDefault();
            if (student != null && teacher != null)
            {
                UsersInfoModel.TeacherOfStudent.Add(studentEmail, teacher);
                if (UsersInfoModel.StudentsOfTeacher.ContainsKey(teacherEmail))
                {
                    UsersInfoModel.StudentsOfTeacher[teacherEmail].Add(student);
                }
                else
                {
                    UsersInfoModel.StudentsOfTeacher.Add(teacherEmail, new List<Student> { student });
                }
            }

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChooseTeacherForStudent(string studentEmail)
        {
            var student = this.service.GetAllStudents().Result.ToList().Where(student => student.Email == studentEmail).FirstOrDefault();
            this.info.CurrentStudent = student;
            return this.View(this.info);
        }
    }
}