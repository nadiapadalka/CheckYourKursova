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
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class UsersInfoModel
    {
        public static string AdminEmail { get; set; } = "Admin's email";
        public static Student CurrentStudent { get; set; }
        
        public string CurrentStudentName
        {
            get
            {
                if (CurrentStudent != null)
                {
                    return CurrentStudent.FullName;
                }
                return null;
            }

            set
            {
                this.CurrentStudentName = value;
            }
        }

        public string TeacherInitials { get; set; }

        public string Email { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public static List<string> StudentsNames(IEnumerable<Student> Students)
        {
            List<string> names = new List<string>();
            foreach (var item in Students)
            {
                names.Add(item.FullName);
            }

            return names;
        }

        // public SelectList StudentsList = new SelectList(Students);

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Documentation> Documentations { get; set; }

       // [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public byte[] UploadedImage { get; set; }
        public string ImageUrl { get; set; }
    }
}