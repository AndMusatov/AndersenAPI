using Domain.Core.Forms;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<IdentityResult> RegistrationAsync(RegisterModel registerModel);
        Task DeleteUserAsync(string email);
        Task<SignInResult> LoginAsync(string userName, string password);
    }
}
