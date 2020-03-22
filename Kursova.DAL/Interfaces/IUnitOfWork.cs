using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursova.DAL.Entities;

namespace Kursova.DAL.Interfaces
{
    
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }

        IRepository<Teacher> Teachers { get; }

        //IRepository<Admin> Admins { get; }

        //IRepository<TaskItem> TaskItems { get; }

        //IRepository<TaskChanges> TaskChanges { get; }

        //IRepository<Documentation> Documentations { get; }

        //IRepository<Comment> Comments { get; }
        void Save();
    }
}
