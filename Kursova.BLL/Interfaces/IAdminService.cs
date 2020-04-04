using System;
using System.Collections.Generic;
using System.Text;
using Kursova.BLL.DTO;

namespace Kursova.BLL.Interfaces
{
    public interface IAdminService
    {
        void CreateAdmin(AdminDTO adminDTO);
        AdminDTO GetById(int? id);
        AdminDTO Get(int adminId);
        AdminDTO GetByAdminNameAndPassword(string name, string password);
        string GetName(int adminId);

        IEnumerable<AdminDTO> GetAll();

        void Dispose(int id);
    }
}
