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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Kursova.Models;
using Kursova.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace AuthApp.Controllers
{
    
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
            //return this.View(await this.teacherService.GetAll());
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
                this.projects.AllProjects[0].TeacherMaterials.Add(filename);
            }

            return this.RedirectToAction("Teacher_Kursova");
        }

        //[HttpGet]
        //[Route("/Teacher/ChooseStudent/{studentName}")]
        //public IActionResult ChooseStudent(string studentName)
        //{
        //    this.projects.CurrentProject = this.projects.AllProjects.Where(x => x.StudentName == studentName).FirstOrDefault();
        //        return this.RedirectToAction("Teacher_Kursova");
        //}
	[HttpGet]
        public IActionResult Teacher_notification()
        {
            return View();
        }

	[HttpPost]
        public async Task TSendMessage(string message)
        {
            await _hubContext.Clients.All.SendAsync("TSend", message);
        }
    }
}

