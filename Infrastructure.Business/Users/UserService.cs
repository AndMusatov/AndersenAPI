using Domain.Core.Forms;
using Domain.Core.Models;
using Domain.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces.Users;
using System.Threading.Tasks;

namespace Infrastructure.Business.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> RegistrationAsync(RegisterModel registerModel)
        {
            var user = new User { Email = registerModel.Email, UserName = registerModel.UserName };
            var result = await _userRepository.RegisterUserAsync(user, registerModel.Password);
            await _userRepository.SignInUserAsync(user);
            return result;
        }

        public async Task DeleteUserAsync(string email)
        {
            await _userRepository.RemoveUserAsync(await _userRepository.GetByEmailAsync(email));
        }

        public async Task<SignInResult> LoginAsync(string userName, string password)
        {
            return await _userRepository.PasswordSignInUserAsync(userName, password);
        }
    }
}
