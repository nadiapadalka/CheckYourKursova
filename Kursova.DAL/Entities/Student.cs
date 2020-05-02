// <copyright file="Student.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Entities
{
    public class Student
    {
        public Student()
        {
        }

        public Student(int id, string fullName, string group, string kafedra, string email, string password)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Group = group;
            this.Kafedra = kafedra;
            this.Email = email;
            this.Password = password;
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Group { get; set; }

        public string Kafedra { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string TeacherInitials { get; set; }

        public string CourseWorkTitle { get; set; }
        public string ProfilePicture { get; set; }

    }
}
