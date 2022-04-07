using Domain.Core.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Users;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegistrationAsync(model);
                return Ok(result);
            }
            return BadRequest(model);
        }

        [HttpPost("AuthLogin")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(model.UserName, model.Password);
                return Ok(result);
            }
            return BadRequest(model);
        }

        [Authorize]
        [HttpDelete("DeleteLoginedUser")]
        public async Task<IActionResult> DeleteUser()
        {
            await _userService.DeleteUserAsync(User.FindFirstValue(ClaimTypes.Email));
            return Ok();
        }
    }
}
