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

        public IUnitOfWork Database { get; set; }
        
        public void CreateStudent(Student StudentDto)
        {
            
                this.Database.Students.Create(StudentDto);
        }
        public async Task<Student> Get(string username, string fullname)
        {
            _logger.LogInformation($"Getting student by {username} and {fullname}");

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

            if (appLicationUser != null)
            {
                _logger.LogInformation("Got student by email.");
                return _mapper.Map<Student>(appLicationUser);
            }
            else
            {
                _logger.LogWarning($"User with email {email} couldn`t be found.");
                return null;
            }
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

        
       

        public static string strKey = "U2A9/R*41FD412+4-123";

        public static string Encrypt(string strData)
        {
            string strValue = " ";
            if (!string.IsNullOrEmpty(strKey))
            {
                if (strKey.Length < 16)
                {
                    char c = "XXXXXXXXXXXXXXXX"[16];
                    strKey = strKey + strKey.Substring(0, 16 - strKey.Length);
                }

                if (strKey.Length > 16)
                {
                    strKey = strKey.Substring(0, 16);
                }

                // create encryption keys
                byte[] byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(strKey.Substring(strKey.Length - 8, 8));

                // convert data to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(strData);

                // encrypt 
                DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
                MemoryStream objMemoryStream = new MemoryStream();
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write);
                objCryptoStream.Write(byteData, 0, byteData.Length);
                objCryptoStream.FlushFinalBlock();

                // convert to string and Base64 encode
                strValue = Convert.ToBase64String(objMemoryStream.ToArray());
            }
            else
            {
                strValue = strData;
            }

            return strValue;
        }

     

       

        
    }
}