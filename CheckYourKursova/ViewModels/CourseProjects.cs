// <copyright file="CourseProjects.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Initializes a new instance of the <see cref="CourseProjects"/> class.
    /// </summary>
    public class CourseProjects
    {
        public List<ProjectInfo> AllProjects { get; set; } = new List<ProjectInfo>();

        public ProjectInfo CurrentProject { get; set; } = new ProjectInfo();
    }
}
