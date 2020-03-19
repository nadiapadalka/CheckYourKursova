using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

using Kursova.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kursova.DAL.EF
{
    public class KursovaDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<TaskItemEntity> TaskItems { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<DocumentationEntity> Documentations { get; set; }
        public DbSet<TaskChangesEntity> TaskChanges { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }


    }
}
