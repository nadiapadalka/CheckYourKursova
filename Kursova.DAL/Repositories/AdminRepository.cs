using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Kursova.DAL.EF;
//using Kursova.DAL.Entities;
//using Kursova.DAL.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//namespace Kursova.DAL.Repositories
//{
//    public class AdminRepository : IRepository<Admin>
//    {
//        private KursovaDbContext db;

//        public AdminRepository(KursovaDbContext context)
//        {
//            this.db = context;
//        }

//        public IEnumerable<Admin> GetAll()
//        {
//            return this.db.Admins;
//        }
//        public async Task<Admin> GetbyEmailandInitials(string email, string password)
//        {
//            return await this.db.Admins.FirstOrDefaultAsync(u => u.Name == email && u.Password == password);

//        }
//        public IEnumerable<Admin> Find(Func<Admin, bool> predicate)
//        {
//            return this.db.Admins.Where(predicate).ToList();
//        }

//        public void Create(Admin admin)
//        {
//            this.db.Admins.Add(admin);
//        }

//        public void Delete(int id)
//        {
//            Admin admin = this.db.Admins.Find(id);
//            if (admin != null)
//            {
//                this.db.Admins.Remove(admin);
//            }
//        }


//    }
//}
