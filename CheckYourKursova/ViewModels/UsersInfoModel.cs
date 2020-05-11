// <copyright file="UsersInfoModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Kursova.DAL.Entities;
    using Microsoft.AspNetCore.Http;

    public class UsersInfoModel
    {
        public static string AdminEmail { get; set; } = "Admin's email";

        public Student CurrentStudent { get; set; }

        public string StudentInitials { get; set; }

        public string TeacherInitials { get; set; }

        public string Email { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Documentation> Documentations { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        // [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public byte[] UploadedImage { get; set; }

        public string ImageUrl { get; set; }
    }
}