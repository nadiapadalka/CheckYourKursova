// <copyright file="TeacherServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.Tests
{
    using System;
    using Kursova.BLL.Services;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class TeacherServiceTest : IDisposable
    {
        private readonly ILogger<StudentService> logger;

        private KursovaDbContext context;
        private DbContextOptions<KursovaDbContext> options = new DbContextOptionsBuilder<KursovaDbContext>()
                       .UseInMemoryDatabase(databaseName: "TeacherDatabase")
                       .Options;

        private TeacherService CreateteacherService()
        {
            this.context = new KursovaDbContext(this.options);
            return new TeacherService(new EFUnitOfWork(this.context), this.logger);
        }

        public void Dispose()
        {
            this.context.Database.EnsureDeleted();
        }

        private TeacherService CreateTestTeachers()
        {
            TeacherService teacherService = this.CreateteacherService();
            teacherService.CreateTeacher(new Teacher
            {
                Id = 132,
                Initials = "Oleksii Nyzhyuk",
                Grade = "Professor",
                Kafedra = "Programming",
                Email = "oleksii@com",
                Password = "2288",
            });
            teacherService.CreateTeacher(new Teacher
            {
                Id = 122,
                Initials = "Nadiia Padalka",
                Grade = "dean",
                Kafedra = "Programming",
                Email = "nadiiapadalka@com",
                Password = "2124",
            });
            return teacherService;
        }

        [Fact]
        public void TestCreateTeacherMethod()
        {
            var teacherService = this.CreateTestTeachers();

            var res = teacherService.GetAll();

            Assert.NotNull(res);
        }

        [Fact]
        public void GetTeacher()
        {
            var teacherService = this.CreateTestTeachers();
            var res = teacherService.Get("nadiiapadalka@com", "Nadiia Padalka");
            Assert.NotNull(res);
        }

        [Fact]
        public void TestGetAll()
        {
            var teacherService = this.CreateTestTeachers();

            var res = teacherService.GetAll();

            Assert.True(res.IsCompleted);
        }
    }
}
