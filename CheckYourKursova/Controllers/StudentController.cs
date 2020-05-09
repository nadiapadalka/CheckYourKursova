namespace Kursova.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.Hubs;
    using Kursova.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> log;
        private readonly IStudentService service;
        private readonly KursovaDbContext db;
        private readonly ITeacherService teacherService;
	    private readonly IHubContext<NotifyHub> _hubContext;

        private KursovaPageModel info = new KursovaPageModel();

        public StudentController(KursovaDbContext database, IStudentService studentService, ILogger<StudentController> logger, IHubContext<NotifyHub> hubContext)
        {
            this.db = database;
            this.service = studentService;
            this.log = logger;
            _hubContext = hubContext;
            // info.Teachers = this.service.GetAllTeachers().Result.ToList();
            //info.Students = this.service.GetAll().Result;
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
                Student result = await this.service.Get(model.Email, model.Password);
                if (result != null)
                {
                    await this.Authenticate(model.Email);
                    this.log.LogInformation($"Student loginned successfully ");
                    string name = result.FullName;
                    this.Folder(name, "Create");

                    return this.RedirectToAction("Student_home", "Admin");
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
		            await SendMessage(" Зарестровано нового студента.");

                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.log.LogInformation("Student exists!  ");
                }
            }

            return this.View(model);
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return this.View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddComment(string email, KursovaPageModel model)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        var user = await this.db.Students.FirstOrDefaultAsync(u => u.Email == email);
        //        this.log.LogInformation("Student in comment controller found!");
        //        if (user != null)
        //        {
        //            this.db.Add(new Comment { Initials = user.FullName, CourseWork = user.CourseWorkTitle, Description = model.Comment });
        //            this.db.SaveChanges();
        //            this.log.LogInformation("Comment added successfully ");

        //            return this.RedirectToAction("Student_Kursova", "Student");
        //        }
        //        else
        //        {
        //              this.log.LogInformation("Student do not exist!  ");
        //        }
        //    }

        //    return this.View(model);
        //}

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

	public IActionResult Student_notification()
        {
            return View();
        }

        [HttpPost]
        public async Task SendMessage(string message)
        {
            await _hubContext.Clients.All.SendAsync("Send", message);
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
    }
}