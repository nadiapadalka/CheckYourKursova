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

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Documentation> Documentations { get; set; }
    }
}