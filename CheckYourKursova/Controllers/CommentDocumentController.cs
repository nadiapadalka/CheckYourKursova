
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

    public class CommentDocumentController : Controller
    {

        private readonly KursovaDbContext db;
        private KursovaPageModel info = new KursovaPageModel();
        private readonly ILogger<CommentDocumentController> log;

        public CommentDocumentController(KursovaDbContext context)
        {
            this.db = context;

            //this.info.Students = this.db.Students;
            //this.info.Teachers = this.db.Teachers;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(string email, KursovaPageModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.db.Students.FirstOrDefaultAsync(u => u.Email == email);
                log.LogInformation("Student in comment controller found!");
                if (user != null)
                {
                    this.db.Add(new Comment { Initials = user.FullName, CourseWork = user.CourseWorkTitle, Description = model.Comment });
                    this.db.SaveChanges();
                //    this.log.LogInformation("Comment added successfully ");

                    return this.RedirectToPage("/Student/Student_Kursova");
                }
                else
                {
                  //  this.log.LogInformation("Student do not exist!  ");
                }
            }

            return this.View(model);
        }

    }
}