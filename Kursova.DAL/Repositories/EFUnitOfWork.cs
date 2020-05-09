// <copyright file="EFUnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Repositories
{
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Interfaces;

    public class EFUnitOfWork : IUnitOfWork
    {
        private KursovaDbContext db;
        private StudentRepository studentRepository;
        private TeacherRepository teacherRepository;
        private AdminRepository adminRepository;

        public EFUnitOfWork(KursovaDbContext db)
        {
            this.db = db;
            this.studentRepository = new StudentRepository(db);
            this.teacherRepository = new TeacherRepository(db);
            this.adminRepository = new AdminRepository(db);
        }

        public IRepository<Student> Students
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(this.db);
                }

                return this.studentRepository;
            }
        }

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (this.teacherRepository == null)
                {
                    this.teacherRepository = new TeacherRepository(this.db);
                }

                return this.teacherRepository;
            }
        }

        public IRepository<Admin> Admins
        {
            get
            {
                if (this.adminRepository == null)
                {
                    this.adminRepository = new AdminRepository(this.db);
                }

                return this.adminRepository;
            }
        }

        public async void Save()
        {
            await this.db.SaveChangesAsync();
        }
    }
}
