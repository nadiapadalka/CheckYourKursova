// <copyright file="AdminController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.Controllers
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
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class AdminController : Controller
    {
        private KursovaDbContext db;
        private IAdminService service;
        private UsersInfoModel info = new UsersInfoModel();
        private readonly ILogger<StudentController> log;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminController(KursovaDbContext context, IAdminService service, ILogger<StudentController> log, IWebHostEnvironment hostEnvironment)
        {
            this.db = context;
            this.service = service;
            this.log = log;
            this.webHostEnvironment = hostEnvironment;
            Update(this.info);
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
                if (result != null)
                {
                    await this.Authenticate(model.Email);

                    UsersInfoModel.AdminEmail = model.Email;

                    return this.RedirectToAction("Index", "Admin");
                }

                this.ModelState.AddModelError(string.Empty, "Некорректний логін і(або) пароль");
            }

            return this.StatusCode(500, "Internal Server Error");
        }

        [HttpGet]
        public IActionResult Index()
        {
            // this.Update(this.info);
            return this.View(this.info);
        }

        [HttpGet]
        public IActionResult Student_home()
        {
            // this.Update(this.info);
            return this.View(this.info);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string email, IFormFile img)
        {
            Student stud = await this.service.GetStudentByEmail(email);

            if (stud != null && img != null)
            {
                this.info.UploadedImage = GetByteArrayFromImage(img);

                string filename = System.IO.Path.GetFileName(img.FileName);
                //string path = Path.Combine("~/files/uploadedfiles/" + filename);

                stud.ProfilePicture = filename;
                this.ViewBag.url = filename;
                this.log.LogInformation($"image not null{stud.ProfilePicture}");
                this.service.UpdateStudent(stud);
                using (FileStream stream = new FileStream($"..\\CheckYourKursova\\wwwroot\\Users\\{stud.FullName}\\Uploaded files\\{filename}", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    img.CopyTo(stream);
                }

                return this.RedirectToAction("Student_home", "Admin");
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeachersImage(string email, IFormFile img)
        {
            Teacher teacher = await this.service.GetTeacherByEmail(email);

            if (teacher != null && img != null)
            {
                this.info.UploadedImage = this.GetByteArrayFromImage(img);

                string filename = System.IO.Path.GetFileName(img.FileName);
                teacher.ProfilePicture = filename;
                this.log.LogInformation($"image not null{teacher.ProfilePicture}");
                this.service.UpdateTeacher(teacher);
                using (FileStream stream = new FileStream($"..\\CheckYourKursova\\wwwroot\\Users\\{teacher.Initials}\\Uploaded files\\{filename}", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    img.CopyTo(stream);
                }

                return this.RedirectToAction("Teacher_home", "Admin");
            }

            return this.RedirectToAction("Index");
        }

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        [HttpGet]
        public IActionResult Teacher_home()
        {
            return this.View(this.info);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(string email, int name)
        {
            Student stud = await this.service.GetStudentByEmail(email);
            if (stud != null)
            {
                stud.TeacherInitials = this.db.Teachers.Where(x => x.Id == name).FirstOrDefault().Initials;
                this.service.UpdateStudent(stud);
                this.log.LogInformation($"Initials {name}");

                return this.RedirectToAction("Student_home", "Admin");
            }

            return this.View(this.info);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentCourseWork(string email, string courseWork)
        {
            Student stud = await this.service.GetStudentByEmail(email);
            if (stud != null)
            {
                stud.CourseWorkTitle = courseWork;
                this.service.UpdateStudent(stud);

                return this.RedirectToAction("Teacher_home", "Admin");
            }

            return this.View(this.info);
        }

        [HttpGet]
        public IActionResult StudentDocuments(string email)
        {
            try
            {
                var student = this.db.Students.Where(x => x.Email == email).FirstOrDefault();
                var documents = this.db.Documentations.Where(x => x.StudentName == student.FullName).ToList();
                this.info.Documentations = documents;
                UsersInfoModel.CurrentStudent = student;
                return this.View(this.info);
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
                var teacherName = this.db.Teachers.Where(x => x.Email == email).FirstOrDefault().Initials;
                var documents = this.db.Documentations.Where(x => x.TeacherName == teacherName).ToList();
                this.info.Documentations = documents;
                this.info.TeacherInitials = teacherName;
                return this.View(this.info);
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

                this.DeleteFolder(stud.FullName);
            }

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

                this.DeleteFolder(teacher.Initials);
            }

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
                student.TeacherInitials = teacher.Initials;
                this.service.UpdateStudent(student);
            }

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChooseTeacherForStudent(string studentEmail)
        {
            var student = this.service.GetAllStudents().Result.ToList().Where(student => student.Email == studentEmail).FirstOrDefault();
            UsersInfoModel.CurrentStudent = student;
            this.Update(this.info);
            return this.View(this.info);
        }

        private void DeleteFolder(string ownerName)
        {
            DirectoryInfo dir = Directory.CreateDirectory("..\\CheckYourKursova\\wwwroot\\Users\\" + ownerName);
            dir.Delete(true);
        }

        private void Update(UsersInfoModel model)
        {
            model.Students = this.service.GetAllStudents().Result.ToList();
            model.Teachers = this.service.GetAllTeachers().Result.ToList();
            model.Documentations = this.db.Documentations.ToList();
        }

        [HttpGet]
        public FileResult DownloadFile(string path)
        {
            // string path = $"..\\CheckYourKursova\\wwwroot\\Users\\{ownerName}\\Uploaded files\\{filename}";
            string filename = string.Empty;
            foreach (var item in path.Split("\\"))
            {
                filename = item;
            }

            byte[] mas = System.IO.File.ReadAllBytes(path);
            string fileType = this.GetFileType(filename);
            return this.File(mas, fileType, filename);
        }

        private string GetFileType(string filename)
        {
            var type = filename.Split(".")[1];
            
            using (StreamReader stream = new StreamReader("..\\CheckYourKursova\\wwwroot\\files\\text.txt"))
            {
                var types = stream.ReadToEnd().Split(" ");
                foreach (var item in types)
                {
                    if (item == type)
                    {
                        return "text/" + item;
                    }
                    if (item == "plain" && type == "txt")
                    {
                        return "text/" + item;
                    }
                }
            }

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

    }
}