// <copyright file="CourseProjects.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System.Collections.Generic;

    public class CourseProjects
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseProjects"/> class.
        /// </summary>
        //public CourseProjects()
        //{
        //    this.AllProjects.Add(
        //    new ProjectInfo()
        //    {
        //        StudentName = "Shevchenko T. H.",
        //        CourseProjectName = "Web Development using ASP.NET Core",
        //        StudentMaterials = new List<string>()
        //        {
        //                "Check Your Kursova.pdf",
        //                "testFileToCheckDownloading.xml",
        //                "TestFileToCheckDownloading.docx",
        //        },
        //    });
        //    this.CurrentProject = this.AllProjects[0];
        //}

        public List<ProjectInfo> AllProjects { get; set; } = new List<ProjectInfo>();

        public ProjectInfo CurrentProject { get; set; } = new ProjectInfo();
    }
}
