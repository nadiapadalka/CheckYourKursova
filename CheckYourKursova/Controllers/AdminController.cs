using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kursova.BLL.DTO;
using Kursova.BLL.Interfaces;
using Kursova.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kursova.Controllers
{
    public class AdminController : Controller
    {
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IAdminService adminService;

        [HttpGet]
        public IActionResult Index()
        {
            UsersInfoModel info = new UsersInfoModel();
            //info.Students = studentService.GetAll();
            //info.Teachers = teacherService.GetAll();

            info.Students = new List<StudentDTO>() { new StudentDTO() { Id = 2, FullName = "Jimi Hendrix",
                Group = "PMI31", Kafedra = "Programming", Email = "j.hendrix@gmail.com" } };
            info.Teachers = new List<TeacherDTO>() { new TeacherDTO() { Id = 3, Initials = "S. S. Haudson", Grade = "A",
                Kafedra = "Programming", Email = "s.haudson@gmail.com" } };
            return View(info);
        }

    }
}