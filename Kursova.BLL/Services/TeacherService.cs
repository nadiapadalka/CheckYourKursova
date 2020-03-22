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
namespace Kursova.BLL.Services
{


    public class TeacherService : ITeacherService
    {
        public TeacherService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }


        public void CreateTeacher(TeacherDTO TeacherDto)
        {
            Teacher Teacher = new Teacher
            {
                Id = TeacherDto.Id,
                Initials = TeacherDto.Initials,
                Grade = TeacherDto.Grade,
                Kafedra = TeacherDto.Kafedra,
                Email = TeacherDto.Email,
                Password = TeacherDto.Password,

            };
            try
            {
                this.Database.Teachers.GetAll().Where(e => e.Email == Teacher.Email).First();
                throw new ArgumentNullException();
            }
            catch (System.InvalidOperationException)
            {
                this.Database.Teachers.Create(Teacher);
                this.Database.Save();
            }
        }


        public string GetInitials(int TeacherAccountId)
        {
            var result = this.GetAll()
                .Where(x => x.Id == TeacherAccountId)
                .Select(x => x.Initials)
                .FirstOrDefault();

            return result;
        }

        public TeacherDTO Get(int TeacherAccountId)
        {
            var result = this.GetAll()
                .FirstOrDefault(x => x.Id == TeacherAccountId);

            return result;
        }


        public TeacherDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.");
            }

            var Teacher = this.Database.Teachers.Get(id.Value);
            if (Teacher == null)
            {
                throw new ValidationException("Teacher with this ID was not found");
            }

            return new TeacherDTO
            {
                Id = Teacher.Id,
                Initials = Teacher.Initials,
                Grade = Teacher.Grade,
                Kafedra = Teacher.Kafedra,
                Email = Teacher.Email,
                Password = Teacher.Password
            };
        }

        public IEnumerable<TeacherDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Teacher, TeacherDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Teacher>, List<TeacherDTO>>(this.Database.Teachers.GetAll());
        }

        
        public void Dispose(int id)
        {
            var Teacher = this.Database.Teachers.Get(id);
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




        public TeacherDTO GetByTeacherInitialsPassword(string Teachername, string password)
        {
            try
            {
                var Teacher = this.Database.Teachers.GetbyPass(Teachername, Encrypt(password));
                return new TeacherDTO
                {
                    Id = Teacher.Id,
                    Initials = Teacher.Initials,
                    Grade = Teacher.Grade,
                    Kafedra = Teacher.Kafedra,
                    Email = Teacher.Email,
                    Password = Teacher.Password
                };
            }
            catch (System.NullReferenceException)
            {
                return null;
            }
        }


    }
}