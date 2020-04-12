// <copyright file="StudentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Interfaces;
    using Microsoft.Extensions.Logging;

    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> logger;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork uow, ILogger<StudentService> logger)
        {
            this.Database = uow;
            this.logger = logger;
        }

        public StudentService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public void CreateStudent(Student user)
        {
          this.Database.Students.Create(user);
        }

        public async Task<Student> Get(string username, string fullname)
        {
           var result = await this.Database.Students.GetbyEmailandInitials(username, fullname);
           if (result != null)
            {
                this.logger.LogInformation($"Getting student by {username} and {fullname}");
            }
            else
            {
                this.logger.LogInformation($"Couldn't find a student by {username} and {fullname}");
            }

           return result;
        }

        public async Task<Student> GetbyEmail(string email)
        {
            var appLicationUser = await this.Database.Students.GetbyEmailAsync(email);
            return appLicationUser;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            this.logger.LogInformation($"Getting all students.");

            return await this.Database.Students.GetAll();
        }

        public void Update(Student user)
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
    }
}