// <copyright file="TeacherDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.DTO
{
    public class TeacherDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherDTO"/> class.
        /// </summary>
        public TeacherDTO() { }

        public int Id { get; set; }

        public string Initials { get; set; }

        public string Grade { get; set; }

        public string Kafedra { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
