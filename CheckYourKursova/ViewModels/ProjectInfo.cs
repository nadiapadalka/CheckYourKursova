// <copyright file="ProjectInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System.Collections.Generic;

    public class ProjectInfo
    {
        public string StudentName { get; set; }

        public string CourseProjectName { get; set; }

        public IEnumerable<string> StudentMaterials { get; set; } = new List<string>();

        public List<string> TeacherMaterials { get; set; } = new List<string>();
    }
}
