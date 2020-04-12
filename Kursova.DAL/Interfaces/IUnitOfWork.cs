// <copyright file="IUnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Interfaces
{
    using Kursova.DAL.Entities;

    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }

        IRepository<Teacher> Teachers { get; }

       // IRepository<Admin> Admins { get; }

        // IRepository<TaskItem> TaskItems { get; }

        // IRepository<TaskChanges> TaskChanges { get; }

        // IRepository<Documentation> Documentations { get; }

        // IRepository<Comment> Comments { get; }
        void Save();
    }
}
