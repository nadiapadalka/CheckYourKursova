// <copyright file="AdminService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// namespace Kursova.BLL.Services
// {
//    class AdminService : IAdminService
//    {
//        private IUnitOfWork Database { get; set; }
//        public AdminService(IUnitOfWork uow)
//        {
//            this.Database = uow;
//        }
//        public void CreateAdmin(AdminDTO adminDTO)
//        {
//            Admin admin = new Admin()
//            {
//                Id = adminDTO.Id,
//                Name = adminDTO.Name,
//                Password = adminDTO.Password
//            };
//            var check = this.Database.Admins.GetAll().Where(x => x.Id == admin.Id).First();
//            if (check == null)
//            {
//                this.Database.Admins.Create(admin);
//                this.Database.Save();
//            }
//            else
//            {
//                throw new Exception("The user allready exists");
//            }
//        }

// public void Dispose(int id)
//        {
//            var admin = this.Database.Admins.Get(id);
//            if (admin != null)
//            {
//                this.Database.Admins.Delete(id);
//                this.Database.Save();
//            }
//        }

// public AdminDTO Get(int adminId)
//        {
//            var admin = this.GetAll().FirstOrDefault(x => x.Id == adminId);
//            return admin;
//        }

// public IEnumerable<AdminDTO> GetAll()
//        {
//            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>()).CreateMapper();
//            return mapper.Map<IEnumerable<Admin>, List<AdminDTO>>(this.Database.Admins.GetAll());
//        }

// public AdminDTO GetByAdminNameAndPassword(string name, string password)
//        {
//            Admin admin = this.Database.Admins.GetbyPass(name, Encrypt(password));
//            if (admin != null)
//            {
//                return new AdminDTO(admin.Id, admin.Name, admin.Password);
//            }
//            return null;
//        }

// public AdminDTO GetById(int? id)
//        {
//            if (id == null)
//            {
//                throw new ValidationException("ID not set.");
//            }

// Admin admin = this.Database.Admins.Get(id.Value);
//            if (admin == null)
//            {
//                throw new ValidationException("Admin with this ID was not found");
//            }
//            return new AdminDTO(admin.Id, admin.Name, admin.Password);
//        }

// public string GetName(int adminId)
//        {
//            throw new NotImplementedException();
//        }

//
