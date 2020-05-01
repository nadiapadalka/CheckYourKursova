// <copyright file="AdminService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Interfaces;
    using Microsoft.Extensions.Logging;

    public class AdminService : IAdminService
    {
        private readonly ILogger<StudentService> logger;
        private readonly IMapper mapper;

        public AdminService(IUnitOfWork uow, ILogger<StudentService> logger)
        {
            this.Database = uow;
            this.logger = logger;
        }

        public AdminService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public void UpdateStudent(Student user)
        {
            this.logger.LogInformation($"Updating student data. Changing password to {user.Password}");

            this.Database.Students.Update(user);
        }

        public void Dispose(int id)
        {
            var student = this.Database.Students.GetbyID(id);
            if (student != null)
            {
                this.Database.Teachers.Delete(id);
            }
        }

        // For Admin
        public void CreateAdmin(Admin admin)
        {
            this.Database.Admins.Create(admin);
        }

        public async Task<Admin> GetAdminByName(string name)
        {
            var appLicationUser = await this.Database.Admins.GetbyEmailAsync(name);
            return appLicationUser;
        }

        public Task<Admin> GetAdmin(string username, string password)
        {
            var admin = this.Database.Admins.GetbyEmailandInitials(username, password);
            if (admin != null)
            {
                this.logger.LogInformation($"Getting admin by {username} and {password}");
            }
            else
            {
                this.logger.LogInformation($"Couldn't find a admin by {username} and {password}");
            }

            return admin;
        }

        public Task<Admin> GetAdminByEmail(string username)
        {
            var admin = this.Database.Admins.GetbyEmailAsync(username);
            if (admin != null)
            {
                this.logger.LogInformation($"Getting admin by {username}.");
            }
            else
            {
                this.logger.LogInformation($"Couldn't find an admin by {username}.");
            }

            return admin;
        }

        public Task<Student> GetStudentByEmail(string username)
        {
            var student = this.Database.Students.GetbyEmailAsync(username);
            if (student != null)
            {
                this.logger.LogInformation($"Getting studet by {username}.");
            }
            else
            {
                this.logger.LogInformation($"Couldn't find an admin by {username}.");
            }

            return student;
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            this.logger.LogInformation($"Getting all admins.");
            return await this.Database.Admins.GetAll();
        }

        public void UpdateAdmin(Admin admin)
        {
            this.logger.LogInformation($"Updating admin data. Changing password to {admin.Password}.");
            this.Database.Admins.Update(admin);
        }

        // For Users
        public Task<IEnumerable<Student>> GetAllStudents()
        {
            this.logger.LogInformation($"Getting all students.");
            return this.Database.Students.GetAll();
        }

        public Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            this.logger.LogInformation($"Getting all students.");
            return this.Database.Teachers.GetAll();
        }

        public void DeleteStudentByEmail(string email)
        {
            var student = this.Database.Students.GetAllToList().Where(x => x.Email == email).FirstOrDefault();
            if (student != null)
            {
                // SaveChanges();
                this.Database.Students.Delete(student.Id);
            }
        }

        public void DeleteTeacherByEmail(string email)
        {
            var teacher = this.Database.Teachers.GetAllToList().Where(x => x.Email == email).FirstOrDefault();
            if (teacher != null)
            {
                // SaveChanges();
                this.Database.Teachers.Delete(teacher.Id);
            }
        }
    }
}