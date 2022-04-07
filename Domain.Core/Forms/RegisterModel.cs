using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Forms
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [StringLength(25)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан Username")]
        [StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [StringLength(25)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        [StringLength(25)]
        public string ConfirmPassword { get; set; }
    }
}
