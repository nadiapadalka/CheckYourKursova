using System.Collections.Generic;
using Kursova.BLL.DTO;

namespace Kursova.BLL.Interfaces
{

    public interface IStudentService
    {
        void CreateStudent(StudentDTO StudentDto);
        StudentDTO GetById(int? id);
        StudentDTO Get(int StudentAccountId);
        StudentDTO GetByStudentnamePassword(string Studentname, string password);
        string GetFirstName(int StudentAccountId);

        IEnumerable<StudentDTO> GetAll();

        void Dispose(int id);

    }
}