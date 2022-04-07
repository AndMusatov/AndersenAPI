using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.UserOrders;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UserOrderController : Controller
    {
        private readonly IUserOrderService _userOrderService;

        public UserOrderController(IUserOrderService userOrderService)
        {
            _userOrderService = userOrderService;
        }

        [HttpPut("MakeOrder")]
        public async Task<ActionResult> MakeOrder(int listId)
        {
            return Ok(await _userOrderService.MakeOrderAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), listId));
        }

        [HttpGet("GetAuthUserOrders")]
        public async Task<ActionResult> GetUserOrders()
        {
            return Ok(await _userOrderService.GetUserOrderAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}
