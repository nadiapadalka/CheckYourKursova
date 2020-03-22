
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
        IEnumerable<T> GetAll();

        T Get(int id);

        T GetbyPass(string username, string password);

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Create(T item);

        //void Update(T item);

        void Delete(int id);
    }
}
