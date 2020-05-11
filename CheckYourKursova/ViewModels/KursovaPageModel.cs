// <copyright file="KursovaPageModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;

    public class KursovaPageModel
    {
        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Documentation> Documentation { get; set; }

        public string Comment { get; set; }

        public string Document
        {
            get; set;
        }
    }
}
