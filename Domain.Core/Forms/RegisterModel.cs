using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Forms
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан Username")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string ConfirmPassword { get; set; }
    }
}
