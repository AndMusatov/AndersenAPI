using Domain.Core.Models;
using Domain.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Users
{
    public class UserRepository : IUserRepository
    {

        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RemoveUserAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> RegisterUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task SignInUserAsync(User user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<SignInResult> PasswordSignInUserAsync(string user, string password)
        {
            return await _signInManager.PasswordSignInAsync(user, password, false, false);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return null;
            return user;
        }
    }
}
