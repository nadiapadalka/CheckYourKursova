// <copyright file="StudentServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTestProject1
{
    using System;
    using Kursova.BLL.Services;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class StudentServiceTest : IDisposable
    {
        private KursovaDbContext databaseContext;
        private DbContextOptions<KursovaDbContext> options = new DbContextOptionsBuilder<KursovaDbContext>()
                      .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                      .Options;

        private KursovaDbContext CreateDatabase()
        {
            this.databaseContext = new KursovaDbContext(this.options);
            return this.databaseContext;
        }

        private StudentService CreateStudentService()
        {
            this.databaseContext = this.CreateDatabase();
            return new StudentService(new EFUnitOfWork(this.databaseContext));
        }

        private StudentService CreateTestStudents()
        {
            StudentService studentService = this.CreateStudentService();
            studentService.CreateStudent(new Student
            {
                Id = 132,
                FullName = "Yaroslav Nolkuchak",
                Group = "Pmi31",
                Kafedra = "Programming",
                Email = "simonnolkuchak@com",
                Password = "1178",
            });
            studentService.CreateStudent(new Student
            {
                Id = 122,
                FullName = "Nadiia Padalka",
                Group = "Pmi33",
                Kafedra = "Programming",
                Email = "nadiiapadalka@com",
                Password = "2124",
            });
            return studentService;
        }

        public void Dispose()
        {
            this.databaseContext.Database.EnsureDeleted();
        }

        [Fact]
        public void TestCreateStudentMethod()
        {
            var studentService = this.CreateTestStudents();
            var res = studentService.GetAll();
            Assert.NotNull(res);
        }

        [Fact]
        public void TestDeleteStudentMethod()
        {
            var studentService = this.CreateStudentService();
            studentService.CreateStudent(new Student
            {
                Id = 132,
                FullName = "Yaroslav Nolkuchak",
                Group = "Pmi31",
                Kafedra = "Programming",
                Email = "simonnolkuchak@com",
                Password = "1178",
            });
            studentService.CreateStudent(new Student
            {
                Id = 122,
                FullName = "Mariia Padalka",
                Group = "Pmi33",
                Kafedra = "Programming",
                Email = "mariiapadalka@com",
                Password = "2124",
            });
            studentService.Dispose(122);
            var res = studentService.GetbyEmail("nadiapadalka@com");
            Assert.True(res.IsCompleted);
        }

        [Fact]
        public void TestGetStudentMethod()
        {
            var studentService = this.CreateStudentService();
            var res = studentService.Get("nadiapadalka@com", "Nadiia Padalka");

            Assert.True(res.IsCompleted);
        }
    }
}
