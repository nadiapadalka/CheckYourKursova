using Kursova.DAL.Entities;
using System;
using Kursova.BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.ViewModels
{
    public class UsersInfoModel
    {
        public string AdminName { get; set; } = "Admin's name";
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}