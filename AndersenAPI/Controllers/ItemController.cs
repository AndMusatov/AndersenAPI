using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Items;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("GetItem")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _itemService.GetItemAsync(id));
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(string name)
        {
            return Ok(await _itemService.AddItemAsync(name));
        }

        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return Ok(await _itemService.DeleteItemAsync(id));
        }

        [HttpPatch("UpdateItem")]
        public async Task<IActionResult> UpdateItem(int id, string newName)
        {
            return Ok(await _itemService.UpdateItemAsync(id, newName));
        }
    }
}
