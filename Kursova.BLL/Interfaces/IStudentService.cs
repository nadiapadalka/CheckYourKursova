using System.Collections.Generic;
using Kursova.BLL.DTO;
using System;
using Kursova.DAL.Entities;
using System.Threading.Tasks;
namespace Kursova.BLL.Interfaces
{

    public interface IStudentService
    {
        //Task<StudentDTO> CreateStudentAsync(StudentDTO Student);
        void CreateStudent(Student student);
        Task<Student> Get(string username, string fullname);
        Task<Student> GetbyEmail(string username);
        Task<IEnumerable<Student>> GetAll();

        void Update(Student student);

    }
}