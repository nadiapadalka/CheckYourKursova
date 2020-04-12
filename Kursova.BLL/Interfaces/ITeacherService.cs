using System.Collections.Generic;
using Kursova.BLL.DTO;
using Kursova.DAL.Entities;
using System.Threading.Tasks;
namespace Kursova.BLL.Interfaces
{

    public interface ITeacherService
    {
        void CreateTeacher(Teacher TeacherDto);
        Task<Teacher> Get(string username, string fullname);
        Task<IEnumerable<Teacher>> GetAll();
        void Update(Teacher teacher);
        IEnumerable<Teacher> AllToList();


    }
}
