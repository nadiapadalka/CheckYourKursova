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


    public class StudentService : IStudentService
    {
        public StudentService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }
        public void CreateStudent(StudentDTO StudentDto)
        {
            Student Student = new Student
            {
                Id = StudentDto.Id,
                Name = StudentDto.Name,
                Surname = StudentDto.Surname,
                Group = StudentDto.Group,
                Kafedra = StudentDto.Kafedra,
                Email = StudentDto.Email,
                Password = StudentDto.Password,

            };
            try
            {
                this.Database.Students.GetAll().Where(e => e.Name == Student.Name).First();
                throw new ArgumentNullException();
            }
            catch (System.InvalidOperationException)
            {
                this.Database.Students.Create(Student);
                this.Database.Save();
            }
        }
        

        public string GetFirstName(int StudentAccountId)
        {
            var result = this.GetAll()
                .Where(x => x.Id == StudentAccountId)
                .Select(x => x.Name)
                .FirstOrDefault();

            return result;
        }

        public StudentDTO Get(int StudentAccountId)
        {
            var StudentAccount = this.GetAll()
                .FirstOrDefault(x => x.Id == StudentAccountId);

            return StudentAccount;
        }
        

        public StudentDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.");
            }

            var Student = this.Database.Students.Get(id.Value);
            if (Student == null)
            {
                throw new ValidationException("Student with this ID was not found");
            }

            return new StudentDTO
            {
                Id = Student.Id,
                Name = Student.Name,
                Surname = Student.Surname,
                Group = Student.Group,
                Kafedra = Student.Kafedra,
                Email = Student.Email,
                Password = Student.Password,
            };
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(this.Database.Students.GetAll());
        }

        

        public void Dispose(int id)
        {
            var Student = this.Database.Students.Get(id);
            if (Student != null)
            {
                this.Database.Students.Delete(id);
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




        public StudentDTO GetByStudentnamePassword(string Studentname, string password)
        {
            try
            {
                var Student = this.Database.Students.GetbyPass(Studentname, Encrypt(password));
                return new StudentDTO
                {
                    Id = Student.Id,
                    Name = Student.Name,
                    Surname = Student.Surname,
                    Group = Student.Group,
                    Kafedra = Student.Kafedra,
                    Email = Student.Email,
                    Password = Student.Password,
                };
            }
            catch (System.NullReferenceException)
            {
                return null;
            }
        }

        
    }
}