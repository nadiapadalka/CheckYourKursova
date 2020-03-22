using System.Collections.Generic;
using Kursova.BLL.DTO;

namespace Kursova.BLL.Interfaces
{

    public interface ITeacherService
    {
        void CreateTeacher(TeacherDTO TeacherDto);
        TeacherDTO GetById(int? id);
        TeacherDTO Get(int TeacherAccountId);
        TeacherDTO GetByTeacherInitialsPassword(string Teachername, string password);
        string GetInitials(int TeacherAccountId);
        IEnumerable<TeacherDTO> GetAll();
        void Dispose(int id);

    }
}
