using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Kursova.BLL.DTO;
using Kursova.BLL.Interfaces;
using Kursova.DAL.Entities;
using Kursova.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace Kursova.BLL.Services
{


    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork uow, ILogger<StudentService> logger)
        {

            this.Database = uow;
            this._logger = logger;
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

           var result =  await this.Database.Students.GetbyEmailandInitials(username, fullname);
            if(result != null)
            {
                _logger.LogInformation($"Getting student by {username} and {fullname}");
            }
            else
            {
                _logger.LogInformation($"Couldn't find a student by {username} and {fullname}");
            }
            return result;
        }

        public async Task<Student> GetbyEmail(string email)
        {
            var appLicationUser = await Database.Students.GetbyEmailAsync(email);

            //if (appLicationUser != null)
            //{
            //    _logger.LogInformation("Got student by email.");
            //    return _mapper.Map<Student>(appLicationUser);
            //}
            //else
            //{
            //    _logger.LogWarning($"User with email {email} couldn`t be found.");
            //    return null;
            //}
            return appLicationUser;
        }



        public async Task<IEnumerable<Student>> GetAll()


        {
            _logger.LogInformation($"Getting all students.");

           return  await this.Database.Students.GetAll();
        }

        public void Update(Student user)
        {
            _logger.LogInformation($"Updating student data. Changing password to {user.Password}");

            Database.Students.Update(user);
        }

        public void Dispose(int id)
        {
            var Student = this.Database.Students.GetbyID(id);
            if (Student != null)
            {
                this.Database.Teachers.Delete(id);
              //  this.Database.Save();
            }
        }


       

        
    }
}