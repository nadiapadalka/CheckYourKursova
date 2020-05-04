// <copyright file="Teacher.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Entities
{
    public class Teacher
    {
        public Teacher()
        {
        }

        public Teacher(int id, string initials, string grade, string kafedra, string email, string password)
        {
            this.Id = id;
            this.Initials = initials;
            this.Grade = grade;
            this.Kafedra = kafedra;
            this.Email = email;
            this.Password = password;
        }

        public int Id { get; set; }

        public string Initials { get; set; }

        public string Grade { get; set; }

        public string Kafedra { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ProfilePicture { get; set; }

    }
}
