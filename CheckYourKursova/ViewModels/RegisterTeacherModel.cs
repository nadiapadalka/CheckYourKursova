// <copyright file="RegisterTeacherModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterTeacherModel
    {
        public string Initials { get; set; }

        public string Grade { get; set; }

        public string Kafedra { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введений  невірно")]
        public string ConfirmPassword { get; set; }
    }
}
