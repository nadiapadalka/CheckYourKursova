using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.ViewModels
{
    public class CourseProjects
    {
        public List<ProjectInfo> AllProjects { get; set; } = new List<ProjectInfo>();

        public ProjectInfo CurrentProject { get; set; } = new ProjectInfo();

        public CourseProjects()
        {
            this.AllProjects.Add(
            new ProjectInfo()
            {
                StudentName = "Shevchenko T. H.",
                CourseProjectName = "Web Development using ASP.NET Core",
                StudentMaterials = new List<string>()
                {
                        "Check Your Kursova.pdf",
                        "testFileToCheckDownloading.xml",
                        "TestFileToCheckDownloading.docx",
                },
            }
            );
            this.CurrentProject = this.AllProjects[0];
        }
    }
}
