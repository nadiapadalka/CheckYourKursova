using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Kursova.BLL.DTO;
using Kursova.BLL.Interfaces;
using Kursova.DAL.Interfaces;
using Kursova.DAL.Entities;
using AutoMapper;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Kursova.BLL.Services
{
    class AdminService : IAdminService
    {
        private IUnitOfWork Database { get; set; }
        public AdminService(IUnitOfWork uow)
        {
            this.Database = uow;
        }
        public void CreateAdmin(AdminDTO adminDTO)
        {
            Admin admin = new Admin()
            {
                Id = adminDTO.Id,
                Name = adminDTO.Name,
                Password = adminDTO.Password
            };
            var check = this.Database.Admins.GetAll().Where(x => x.Id == admin.Id).First();
            if (check == null)
            {
                this.Database.Admins.Create(admin);
                this.Database.Save();
            }
            else
            {
                throw new Exception("The user allready exists");
            }
        }

        public void Dispose(int id)
        {
            var admin = this.Database.Admins.Get(id);
            if (admin != null)
            {
                this.Database.Admins.Delete(id);
                this.Database.Save();
            }
        }

        public AdminDTO Get(int adminId)
        {
            var admin = this.GetAll().FirstOrDefault(x => x.Id == adminId);
            return admin;
        }

        public IEnumerable<AdminDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Admin>, List<AdminDTO>>(this.Database.Admins.GetAll());
        }

        public AdminDTO GetByAdminNameAndPassword(string name, string password)
        {
            Admin admin = this.Database.Admins.GetbyPass(name, Encrypt(password));
            if (admin != null)
            {
                return new AdminDTO(admin.Id, admin.Name, admin.Password);
            }
            return null;
        }

        public AdminDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.");
            }

            Admin admin = this.Database.Admins.Get(id.Value);
            if (admin == null)
            {
                throw new ValidationException("Admin with this ID was not found");
            }
            return new AdminDTO(admin.Id, admin.Name, admin.Password);
        }

        public string GetName(int adminId)
        {
            throw new NotImplementedException();
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
