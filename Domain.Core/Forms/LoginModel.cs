using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Forms
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан Password")]
        [DataType(DataType.Password)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string Password { get; set; }
    }
}
