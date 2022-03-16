using Microsoft.AspNetCore.Identity;

namespace Domain.Core.Models
{
    public class User : IdentityUser
    {
        public static object Identity { get; set; }
    }
}
