using Kursova.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kursova.DAL.EF
{
    public class KursovaDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Documentation> Documentations { get; set; }
        public DbSet<TaskChanges> TaskChanges { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public KursovaDbContext(DbContextOptions<KursovaDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();


        }

        public void changeUserPasssword(object p)
        {
            throw new NotImplementedException();
        }
    }
}
