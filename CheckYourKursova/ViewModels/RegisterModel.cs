// <copyright file="RegisterModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kursova.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        public string FullName { get; set; }

        public string Group { get; set; }

        public string Kafedra { get; set; }

        [Required(ErrorMessage = "Не вказаний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введений  невірно")]
        public string ConfirmPassword { get; set; }
    }
}
