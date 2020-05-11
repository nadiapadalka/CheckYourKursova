// <copyright file="TeacherRepository.cs" company="PlaceholderCompany">
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

    public class TeacherRepository : IRepository<Teacher>
    {
        private KursovaDbContext db;

        public TeacherRepository(KursovaDbContext context)
        {
            this.db = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await this.db.Teachers.ToListAsync();
        }

        /// <inheritdoc/>
        public IEnumerable<Teacher> GetAllToList()
        {
            return this.db.Teachers.ToList();
        }

        /// <inheritdoc/>
        public void Update(Teacher user)
        {
            this.db.Teachers.Update(user);
            this.db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<Teacher> GetbyEmailandInitials(string email, string password)
        {
            
            return await this.db.Teachers.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        /// <inheritdoc/>
        public async Task<Teacher> GetbyID(int id)
        {
            return await this.db.Teachers.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <inheritdoc/>
        public async Task<Teacher> GetbyEmailAsync(string email)
        {
            return await this.db.Teachers.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <inheritdoc/>
        public void Create(Teacher user)
        {
            this.db.Teachers.Add(user);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            Teacher user = this.db.Teachers.Find(id);
            if (user != null)
            {
                this.db.Teachers.Remove(user);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Teachers.Max(a => a.Id);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }

        public Teacher GetbyPass(string username, string password)
        {
            return this.db.Teachers.Where(a => a.Email == username && a.Password == password).ToList().FirstOrDefault();
        }
    }
}
