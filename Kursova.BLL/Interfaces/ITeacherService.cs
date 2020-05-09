// <copyright file="ITeacherService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Kursova.DAL.Entities;

    public interface ITeacherService
    {
        void CreateTeacher(Teacher teacherDto);

        Task<Teacher> Get(string username, string fullname);
        Task<Teacher> GetbyEmail(string email);

        Task<IEnumerable<Teacher>> GetAll();

        void Update(Teacher teacher);

        IEnumerable<Teacher> AllToList();
    }
}
