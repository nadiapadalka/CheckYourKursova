// <copyright file="KursovaDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.DAL.EF
{
    using System;
    using Kursova.DAL.Entities;
    using Microsoft.EntityFrameworkCore;

    public class KursovaDbContext : DbContext
    {
        public KursovaDbContext(DbContextOptions<KursovaDbContext> options)
            : base(options)
        {
            // this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Documentation> Documentations { get; set; }

        public DbSet<TaskChanges> TaskChanges { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
