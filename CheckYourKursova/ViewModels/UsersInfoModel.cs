// <copyright file="UsersInfoModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Kursova.DAL.Entities;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class UsersInfoModel
    {
        public string AdminName { get; set; } = "Admin's name";

        public Student CurrentStudent { get; set; }
        public string TeacherInitials { get; set; }

        public string Email { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Documentation> Documentations { get; set; }

        public static Dictionary<string, List<Student>> StudentsOfTeacher { get; set; } = new Dictionary<string, List<Student>>();

        // key - student FullName, value - teacher
        public static Dictionary<string, Teacher> TeacherOfStudent { get; set; } = new Dictionary<string, Teacher>();
       // [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public byte[] UploadedImage { get; set; }
        public string ImageUrl { get; set; }
    }
}