using Kursova.BLL.Interfaces;
using Kursova.DAL.EF;
using Kursova.DAL.Entities;
using Kursova.DAL.Repositories;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    public class AdminController : Controller
    {
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IAdminService adminService;
        private KursovaDbContext db;
        private EFUnitOfWork uow;
        public AdminController(KursovaDbContext context)
        {
            db = context;
            uow = new EFUnitOfWork(db);
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
        public IActionResult StudentDocuments(string email)
        {
            try
            {
                var studentId = db.Students.Where(x => x.Email == email).FirstOrDefault().Id;
                var documents = db.Documentations.Where(x => x.UserId == studentId).ToList();
                return View(documents);
            }
            catch (Exception ex)
            {
                // _logger.LogError(...
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult TeacherDocuments(string email)
        {
            try
            {
                var teacherId = db.Teachers.Where(x => x.Email == email).FirstOrDefault().Id;
                var documents = db.Documentations.Where(x => x.UserId == teacherId).ToList();
                return View(documents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult DeleteStudent(string email)
        {
            var stud = db.Students.Where(x => x.Email == email).FirstOrDefault();
            if (stud != null)
            {
                db.Set<Student>().Remove(stud);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteTeacher(string email)
        {
            var teacher = db.Teachers.Where(x => x.Email == email).FirstOrDefault();
            if (teacher != null)
            {
                db.Set<Teacher>().Remove(teacher);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteStudentDocument(int id)
        {
            var document = db.Documentations.Where(doc => doc.Id == id).FirstOrDefault();
            if (document != null)
            {
                db.Set<Documentation>().Remove(document);
                db.SaveChanges();
            }
            return RedirectToAction("StudentDocuments");
        }

        [HttpPost]
        public IActionResult DeleteTeacherDocument(int id)
        {
            var document = db.Documentations.Where(doc => doc.Id == id).FirstOrDefault();
            if (document != null)
            {
                db.Set<Documentation>().Remove(document);
                db.SaveChanges();
            }
            return RedirectToAction("TeacherDocuments");
        }


        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStudent(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Student user = await db.Students.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    db.Students.Add(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Admin");
                }
                else
                    ModelState.AddModelError("", "Некоректний логін і(чи) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View("RegisterTeacher");
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
                    db.Teachers.Add(
                    new Teacher { Email = model.Email, Password = model.Password, Initials = model.Initials, Grade = model.Grade, Kafedra = model.Kafedra });
                    await db.SaveChangesAsync();
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Admin");
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



    }
}