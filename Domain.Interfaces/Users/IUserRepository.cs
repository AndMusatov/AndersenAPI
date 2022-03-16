using Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<Object> RegisterUser(User user, string password);
        Task<Object> GoogleRegisterUser(User user);
        Task SignInUser(User user);
        Task<Object> PasswordSignInUser(string user, string password);
        Task<User> GetByEmail(string email);
        Task RemoveUser(User user);
    }
}
