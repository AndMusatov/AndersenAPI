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

        public async Task RemoveUser(User user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<Object> RegisterUser(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<Object> GoogleRegisterUser(User user)
        {
            return await _userManager.CreateAsync(user);
        }
        public async Task SignInUser(User user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<Object> PasswordSignInUser(string user, string password)
        {
            return await _signInManager.PasswordSignInAsync(user, password, false, false);
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return null;
            return user;
        }
    }
}
