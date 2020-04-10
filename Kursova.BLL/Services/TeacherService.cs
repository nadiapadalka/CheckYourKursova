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
namespace Kursova.BLL.Services
{

    public class TeacherService : ITeacherService
    {
        public TeacherService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }
        public void CreateTeacher(Teacher TeacherDto)
        {
          this.Database.Teachers.Create(TeacherDto);
        }
        public async Task<Teacher> Get(string username, string fullname)
        =>
            await this.Database.Teachers.GetbyEmailandInitials(username, fullname);

        public void Update(Teacher user) => Database.Teachers.Update(user);


        public async Task<IEnumerable<Teacher>> GetAll()


        => await Database.Teachers.GetAll();



        public void Dispose(int id)
        {
            var Teacher = this.Database.Teachers.GetbyID(id);
            if (Teacher != null)
            {
                this.Database.Teachers.Delete(id);
                this.Database.Save();
            }
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