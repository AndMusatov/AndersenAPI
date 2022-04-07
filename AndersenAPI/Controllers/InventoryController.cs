using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Inventories;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("GetInventory")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _inventoryService.GetInventoryAsync(id));
        }

        [HttpPost("AddInventory")]
        public async Task<IActionResult> AddItem(int id, int balance)
        {
            return Ok(await _inventoryService.AddInventoryAsync(id, balance));
        }

        [HttpDelete("DeleteInventory")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return Ok(await _inventoryService.DeleteInventoryAsync(id));
        }

        [HttpPatch("UpdateInventory")]
        public async Task<IActionResult> UpdateItem(int id, int balance)
        {
            return Ok(await _inventoryService.UpdateInventoryAsync(id, balance));
        }
    }
}
