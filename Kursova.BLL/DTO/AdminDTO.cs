// <copyright file="AdminDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AdminDTO
    {
        public AdminDTO()
        {
        }

        public AdminDTO(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
