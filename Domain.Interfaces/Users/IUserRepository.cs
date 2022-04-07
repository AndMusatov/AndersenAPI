using Domain.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(User user, string password);
        Task SignInUserAsync(User user);
        Task<SignInResult> PasswordSignInUserAsync(string user, string password);
        Task<User> GetByEmailAsync(string email);
        Task RemoveUserAsync(User user);
    }
}
