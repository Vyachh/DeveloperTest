using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMIWebApi.Models
{
    public class Pacient
    {
        [Key]
        public int Id { get; set; }
        public string NickName { get; set; } //  Уникальное поле
        public string PasswordHash { get; set; }

        public string? Surname { get; set; } // Фамилия  
        public string? FirstName { get; set; } // Имя
        public string? Patronymic { get; set; } // Отчество

        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }


        public BMIIndex BMIIndex { get; set; }
    }
}
