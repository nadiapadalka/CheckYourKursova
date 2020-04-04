using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova.BLL.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public AdminDTO()
        {

        }
        public AdminDTO(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
