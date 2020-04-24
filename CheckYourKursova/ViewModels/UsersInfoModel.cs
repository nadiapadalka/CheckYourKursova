// <copyright file="UsersInfoModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System.Collections.Generic;
    using Kursova.DAL.Entities;

    public class UsersInfoModel
    {
        public string AdminName { get; set; } = "Admin's name";

        public Student CurrentStudent { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Documentation> Documentations { get; set; }

        // key - teacher Initials, value - list of students
        public static Dictionary<string, List<Student>> StudentsOfTeacher { get; set; } = new Dictionary<string, List<Student>>();

        // key - student FullName, value - teacher
        public static Dictionary<string, Teacher> TeacherOfStudent { get; set; } = new Dictionary<string, Teacher>();

    }
}