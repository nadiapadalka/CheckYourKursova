using System;
using Xunit;
using Kursova.DAL.EF;
using Kursova.DAL.Entities;

using Kursova.DAL.Repositories;
using Kursova.BLL.DTO;
using System.Linq;
using Kursova.BLL.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace UnitTestProject1
{

    public class StudentServiceTest : IDisposable
    {
        KursovaDbContext databaseContext;
        DbContextOptions<KursovaDbContext> options = new DbContextOptionsBuilder<KursovaDbContext>()
                      .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                      .Options;
        KursovaDbContext CreateDatabase()
        {
            databaseContext = new KursovaDbContext(options);
            return databaseContext;
        }

        StudentService CreateStudentService()
        {
            databaseContext = CreateDatabase();
            return new StudentService(new EFUnitOfWork(databaseContext));
        }
        StudentService CreateTestStudents()
        {
            StudentService StudentService = CreateStudentService();


            StudentService.CreateStudent(new Student
            {
                Id = 132,
                FullName = "Yaroslav Nolkuchak",
                Group = "Pmi31",
                Kafedra = "Programming",
                Email = "simonnolkuchak@com",
                Password = "1178"

            });
            StudentService.CreateStudent(new Student
            {
                Id = 122,
                FullName = "Nadiia Padalka",
                Group = "Pmi33",
                Kafedra = "Programming",
                Email = "nadiiapadalka@com",
                Password = "2124"

            });
            return StudentService;
        }

        public void Dispose()
        {
            databaseContext.Database.EnsureDeleted();
        }
        [Fact]
        public void TestCreateStudentMethod()
        {

            var StudentService = CreateTestStudents();

            var res = StudentService.GetAll();


            Assert.NotNull(res);

        }
        //public void TestUpdateStudentMethod()
        //{

        //    var StudentService = CreateTestStudents();
        //    Student student = new Student
        //    {
        //        Id = 122,
        //        FullName = "Nadiia Padalka",
        //        Group = "Pmi33",
        //        Kafedra = "Programming",
        //        Email = "nadiiapadalka@com",
        //        Password = "2124"

        //    };
        //    StudentService.CreateStudent(student);
        //    StudentService.Update

        //    Assert.NotNull(StudentService.GetAll());

        //}

        [Fact]
        public void TestDeleteStudentMethod()
        {
            var StudentService = CreateStudentService();


            StudentService.CreateStudent(new Student
            {
                Id = 132,
                FullName = "Yaroslav Nolkuchak",
                Group = "Pmi31",
                Kafedra = "Programming",
                Email = "simonnolkuchak@com",
                Password = "1178"

            });
            StudentService.CreateStudent(new Student
            {
                Id = 122,
                FullName = "Mariia Padalka",
                Group = "Pmi33",
                Kafedra = "Programming",
                Email = "mariiapadalka@com",
                Password = "2124"

            });
            //var Student = StudentService.GetAll().FirstOrDefault();
            StudentService.Dispose(122);
            var res = StudentService.GetbyEmail("nadiapadalka@com");

            Assert.True(res.IsCompleted);

        }

        [Fact]
        public void TestGetStudentMethod()
        {
            var StudentService = CreateStudentService();


         
            var res = StudentService.Get("nadiapadalka@com", "Nadiia Padalka");

            Assert.True(res.IsCompleted);

        }




    }
}
