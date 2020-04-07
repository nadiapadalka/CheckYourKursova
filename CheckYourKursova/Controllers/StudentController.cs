using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Kursova.DAL.Entities;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Kursova.DAL.EF;


namespace Kursova.Controllers
{
    public class StudentController : Controller
    {
        private KursovaDbContext db;
        public StudentController(KursovaDbContext context)
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

                    return RedirectToAction("Student_home", "Student");
                }
                ModelState.AddModelError("", "Некорректний логін і(або) пароль");
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
                    db.Students.Add(new Student { Email = model.Email, Password = model.Password, FullName = model.FullName, Group = model.Group, Kafedra = model.Kafedra });
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

        public async Task<IActionResult> Student_home()
        {
            return View(await db.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                Student user = await db.Students.FirstOrDefaultAsync(u => u.Email == model.Email && u.FullName == model.FullName);

                user.Password = model.Password;
                db.Students.Update(user);


                await db.SaveChangesAsync();

                await Authenticate(model.Email);

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }
       
    }
}