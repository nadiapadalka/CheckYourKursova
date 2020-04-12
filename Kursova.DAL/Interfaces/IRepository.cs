using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Kursova.DAL.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetbyEmailandInitials(string email,string initials);
        Task<T> GetbyEmailAsync(string email);
        public IEnumerable<T> GetAllToList();

        void Create(T item);
        Task<T> GetbyID(int id);
        void Update(T item);
        void Delete(int id);
    }
}
