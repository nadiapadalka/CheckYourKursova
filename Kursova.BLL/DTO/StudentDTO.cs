// <copyright file="StudentDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.DTO
{
    public class StudentDTO
    {
        public StudentDTO() { }

        public StudentDTO(int student_ID, string fullName, string group, string kafedra, string email)
        {
            this.Id = student_ID;
            this.FullName = fullName;
            this.Email = group;
            this.Group = kafedra;
            this.Email = email;
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Group { get; set; }

        public string Kafedra { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
