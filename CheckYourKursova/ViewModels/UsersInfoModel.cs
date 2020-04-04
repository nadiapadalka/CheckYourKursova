using Kursova.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.ViewModels
{
    public class UsersInfoModel
    {
        public string AdminName { get; set; } = "Admin's name";
        public IEnumerable<StudentDTO> Students { get; set; }
        public IEnumerable<TeacherDTO> Teachers { get; set; }
    }
}