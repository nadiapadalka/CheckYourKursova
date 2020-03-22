using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursova.DAL.EF;
using Kursova.DAL.Entities;
using Kursova.DAL.Interfaces;
namespace Kursova.DAL.Repositories
{


    public class TeacherRepository : IRepository<Teacher>
    {
        private KursovaDbContext db;

        public TeacherRepository(KursovaDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return this.db.Teachers;
        }

        public Teacher Get(int id)
        {
            return this.db.Teachers.Find(id);
        }

        public void Create(Teacher user)
        {
            this.db.Teachers.Add(user);
        }

        //public void Update(Teacher user)
        //{
        //    this.db.Entry(user).State = EntityState.Modified;
        //}

        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return this.db.Teachers.Where(predicate).ToList();
        }

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