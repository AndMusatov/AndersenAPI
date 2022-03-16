using Domain.Core.Forms;
using Domain.Interfaces.Users;
using Infrastructure.Business.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserService authActions = new UserService(_userRepository);
                var result = await authActions.Registration(model);
                return Ok(result);
            }
            return BadRequest(model);
        }

        [HttpPost("AuthLogin")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            UserService authActions = new UserService(_userRepository);
            if (ModelState.IsValid)
            {
                var result = await authActions.Login(model.UserName, model.Password);
                return Ok(result);
            }
            return BadRequest(model);
        }

        [Authorize]
        [HttpDelete("DeleteLoginedUser")]
        public async Task<IActionResult> DeleteUser()
        {
            UserService authActions = new UserService(_userRepository);
            return Ok(await authActions.DeleteUser(User.FindFirstValue(ClaimTypes.Email)));
        }
    }
}
