// <copyright file="StudentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class StudentRepository : IRepository<Student>
    {
        private KursovaDbContext db;

        public StudentRepository(KursovaDbContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
          return await this.db.Students.ToListAsync();
        }

        public async Task<Student> GetbyEmailandInitials(string email, string password)
        {
            return await this.db.Students.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<Student> GetbyEmailAsync(string email)
        {
            return await this.db.Students.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Student> GetbyID(int id)
        {
            return await this.db.Students.FirstOrDefaultAsync(u => u.Id == id);
        }

        public IEnumerable<Student> GetAllToList()
        {
            return this.db.Students.ToList();
        }

        public void Create(Student user)
        {
            this.db.Students.Update(user);
            this.db.SaveChangesAsync();
        }

        public void Update(Student user)
        {
            this.db.Students.Update(user);
            this.db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            Student user = this.db.Students.Find(id);
            if (user != null)
            {
                this.db.Set<Student>().Remove(user);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Students.Max(a => a.Id);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }

        public Student GetbyPass(string username, string password)
        {
            return this.db.Students.Where(a => a.Email == username && a.Password == password).ToList().FirstOrDefault();
        }
    }
}