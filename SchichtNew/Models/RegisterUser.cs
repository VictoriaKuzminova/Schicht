using System.ComponentModel.DataAnnotations;

namespace SchichtNew.Models
{
    public class RegisterUser
    {
        [Required]
        [Display(Name = "Почта")]
        public string?  Email { get; set; }

        [Required]
        [Display(Name ="Логин")]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Поле {0} должно иметь минимум {2} символов.",MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [Display(Name = "Повторите пароль")]
        public string? ConfirmPassword { get; set;}

    }
}
