﻿// <copyright file="AdminRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Kursova.DAL.EF;
    using Kursova.DAL.Entities;
    using Kursova.DAL.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class AdminRepository : IRepository<Admin>
    {
        private KursovaDbContext db;

        public AdminRepository(KursovaDbContext context)
        {
            this.db = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await this.db.Admins.ToListAsync();
        }

        public async Task<Admin> GetbyEmailandPassword(string email, string password)
        {
            return await this.db.Admins.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        /// <inheritdoc/>
        public async Task<Admin> GetbyEmailandInitials(string email, string fullname)
        {
            var result = await this.GetbyEmailandPassword(email, fullname);
            return result;
        }

        /// <inheritdoc/>
        public async Task<Admin> GetbyEmailAsync(string email)
        {
            return await this.db.Admins.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <inheritdoc/>
        public async Task<Admin> GetbyID(int id)
        {
            return await this.db.Admins.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <inheritdoc/>
        public IEnumerable<Admin> GetAllToList()
        {
            return this.db.Admins.ToList();
        }

        /// <inheritdoc/>
        public void Create(Admin user)
        {
            this.db.Admins.Update(user);
            this.db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void Update(Admin user)
        {
            this.db.Admins.Update(user);
            this.db.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            Admin user = this.db.Admins.Find(id);
            if (user != null)
            {
                this.db.Set<Admin>().Remove(user);
            }
        }

        public Admin GetbyPass(string username, string password)
        {
            return this.db.Admins.Where(a => a.Email == username && a.Password == password).ToList().FirstOrDefault();
        }
    }
}