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

    public class AdminServiceTest : IDisposable
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

        private AdminService CreateAdminService()
        {
            this.databaseContext = this.CreateDatabase();
            return new AdminService(new EFUnitOfWork(this.databaseContext));
        }

        private AdminService CreateTestAdmin()
        {
            AdminService adminService = this.CreateAdminService();
            adminService.CreateAdmin(new Admin
            {
                Id = 132,
                Name = "Natalia Savchuk",
                Password = "11178",
            });
            adminService.CreateAdmin(new Admin
            {
                Id = 122,
                Name = "Ira Semchuk",
                Password = "21924",
            });
            return adminService;
        }

        public void Dispose()
        {
            this.databaseContext.Database.EnsureDeleted();
        }

        [Fact]
        public void TestCreateAdminMethod()
        {
            var adminService = this.CreateTestAdmin();
            var res = adminService.GetAllAdmins();
            Assert.NotNull(res);
        }

        [Fact]
        public void TestDeleteAdminMethod()
        {
            var adminService = this.CreateAdminService();
            adminService.CreateAdmin(new Admin
            {
                Id = 132,
                Name = "Natalia Savchuk",
                Password = "11178",
            });
            adminService.CreateAdmin(new Admin
            {
                Id = 122,
                Name = "Ira Semchuk",
                Password = "21924",
            });
            adminService.Dispose(122);
            var res = adminService.GetAdminByName("Ira Semchuk");
            Assert.True(res.IsCompleted);
        }

        [Fact]
        public void TestGetAdminByNameMethod()
        {
            var adminService = this.CreateAdminService();
            var res = adminService.GetAdminByName("Natalia Savchuk");

            Assert.True(res.IsCompleted);
        }

    }
}
