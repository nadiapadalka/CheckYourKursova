using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Kursova.ViewModels
{
    public class RegisterModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }
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
