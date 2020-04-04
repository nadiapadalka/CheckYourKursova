using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kursova.BLL.DTO;
using Kursova.DAL.Entities;
using Kursova.BLL.Interfaces;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Kursova.DAL.EF;

namespace Kursova.Controllers
{
    public class AdminController : Controller
    {
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IAdminService adminService;
        private KursovaDbContext db;
        public AdminController(KursovaDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UsersInfoModel info = new UsersInfoModel();
            info.Students = db.Students;
            info.Teachers = db.Teachers;
            return View(info);
        }

    }
}