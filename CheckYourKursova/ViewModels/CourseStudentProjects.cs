using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.ViewModels
{
    public class CourseStudentProjects
    {
        public List<StudentProjectInfo> AllProjects { get; set; } = new List<StudentProjectInfo>();

        public StudentProjectInfo CurrentProject { get; set; } = new StudentProjectInfo();

        public CourseStudentProjects()
        {
            this.AllProjects.Add(
            new StudentProjectInfo()
            {
                CourseProjectName = "Web Development using ASP.NET Core",
                TeacherMaterials = new List<string>()
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
