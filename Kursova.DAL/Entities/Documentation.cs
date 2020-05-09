// <copyright file="Documentation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Entities
{
    using System.Collections.Generic;

    public class Documentation
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public string StudentName { get; set; }

        public string TeacherName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AttachedStudentMaterials { get; set; }

        public string AttachedTeacherMaterials { get; set; }
    }
}
