using Domain.Core.Forms;
using Domain.Core.Models;
using Domain.Interfaces.Users;
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

        public async Task<object> Registration(RegisterModel registerModel)
        {
            User user = new User { Email = registerModel.Email, UserName = registerModel.UserName };
            var result = await _userRepository.RegisterUser(user, registerModel.Password);
            await _userRepository.SignInUser(user);
            return result;
        }

        public async Task<object> DeleteUser(string email)
        {
            await _userRepository.RemoveUser(await _userRepository.GetByEmail(email));
            return "User was deleted";
        }

        public async Task<object> Login(string userName, string password)
        {
            return await _userRepository.PasswordSignInUser(userName, password);
        }
    }
}
