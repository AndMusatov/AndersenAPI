using Domain.Core.Forms;
using System.Threading.Tasks;

namespace Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<object> Registration(RegisterModel registerModel);
        Task<object> DeleteUser(string email);
        Task<object> Login(string userName, string password);
    }
}
