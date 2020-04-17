// <copyright file="IStudentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Kursova.DAL.Entities;

    public interface IStudentService
    {
        void CreateStudent(Student student);

        Task<Student> Get(string username, string fullname);

        Task<Student> GetbyEmail(string username);

        Task<IEnumerable<Student>> GetAll();

        void Update(Student student);
    }
}