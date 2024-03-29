using System.ComponentModel.DataAnnotations;

namespace SchichtNew.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name ="Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
