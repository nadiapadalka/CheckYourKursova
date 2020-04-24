// <copyright file="IAdminService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Kursova.DAL.Entities;

    public interface IAdminService
    {
        void CreateAdmin(Admin admin);

        Task<Admin> GetAdmin(string username, string password);

        Task<Admin> GetAdminByEmail(string username);

        Task<IEnumerable<Admin>> GetAllAdmins();

        void UpdateAdmin(Admin admin);

        Task<IEnumerable<Student>> GetAllStudents();

        Task<IEnumerable<Teacher>> GetAllTeachers();

        void DeleteStudentByEmail(string email);

        void DeleteTeacherByEmail(string email);
    }
}
