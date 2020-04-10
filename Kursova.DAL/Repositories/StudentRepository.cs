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


    public class StudentRepository : IRepository<Student>
    {
        private KursovaDbContext db;

        public StudentRepository(KursovaDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return this.db.Students;
        }

        public Student Get(int id)
        {
            return this.db.Students.Find(id);
        }

        public void Create(Student user)
        {
            this.db.Students.Add(user);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return this.db.Students.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Student user = this.db.Students.Find(id);
            if (user != null)
            {
                //this.db.Students.Remove(user);
                db.Set<Student>().Remove(user);
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