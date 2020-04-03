using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Kursova.DAL.EF;
using Kursova.DAL.Interfaces;
using Kursova.DAL.Entities;

namespace Kursova.DAL.Repositories
{
    public class AdminRepository : IRepository<Admin>
    {
        private KursovaDbContext db;

        public AdminRepository(KursovaDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Admin> GetAll()
        {
            return this.db.Admins;
        }
        public Admin Get(int id)
        {
            return this.db.Admins.Find(id);
        }
        public IEnumerable<Admin> Find(Func<Admin, bool> predicate)
        {
            return this.db.Admins.Where(predicate).ToList();
        }

        public void Create(Admin admin)
        {
            this.db.Admins.Add(admin);
        }

        public void Delete(int id)
        {
            Admin admin = this.db.Admins.Find(id);
            if (admin != null)
            {
                this.db.Admins.Remove(admin);
            }
        }

        public Admin GetbyPass(string username, string password)
        {
            return this.db.Admins.Where(x => x.Name == username && x.Password == password)
                .ToList().FirstOrDefault();
        }
    }
}
