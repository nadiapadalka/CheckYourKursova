// <copyright file="TeacherService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Kursova.BLL.Interfaces;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Interfaces;
    using Microsoft.Extensions.Logging;

    public class TeacherService : ITeacherService
    {
        private readonly ILogger<StudentService> logger;

        public TeacherService(IUnitOfWork uow, ILogger<StudentService> logger)
        {
            this.Database = uow;
            this.logger = logger;
        }

        public IUnitOfWork Database { get; set; }

        public void CreateTeacher(Teacher teacherDto)
        {
          this.Database.Teachers.Create(teacherDto);
        }

        public async Task<Teacher> Get(string username, string password)
        {
                this.logger.LogInformation($"Getting teacher by {username} and {password}");

                return await this.Database.Teachers.GetbyEmailandInitials(username, password);
        }
        public async Task<Teacher> GetbyEmail(string email)
        {
            this.logger.LogInformation($"Getting teacher by {email} ");

            return await this.Database.Teachers.GetbyEmailAsync(email);
        }

        public void Update(Teacher user)
        {
                this.logger.LogInformation($"Update teacher password  for {user.Initials}");
                this.Database.Teachers.Update(user);
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            this.logger.LogInformation($"Getting all teachers");
            return await this.Database.Teachers.GetAll();
        }

        public IEnumerable<Teacher> AllToList()
        {
            this.logger.LogInformation($"Getting all teachers to list");
            return this.Database.Teachers.GetAllToList();
        }

        public void Dispose(int id)
        {
            var teacher = this.Database.Teachers.GetbyID(id);
            if (teacher != null)
            {
                this.Database.Teachers.Delete(id);
                this.Database.Save();
            }
        }

#pragma warning disable SA1201 // Elements should appear in the correct order
        private static string strKey = "U2A9/R*41FD412+4-123";
#pragma warning restore SA1201 // Elements should appear in the correct order

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