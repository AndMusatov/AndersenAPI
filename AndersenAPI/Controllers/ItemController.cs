using Domain.Interfaces.Items;
using Infrastructure.Business.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class ItemController : Controller
    {
        readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("GetItem")]
        public async Task<IActionResult> GetItem(int id)
        {
            ItemService itemInfrastructure = new ItemService(_itemRepository);
            return Ok(await itemInfrastructure.GetItem(id));
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(string name)
        {
            ItemService itemInfrastructure = new ItemService(_itemRepository);
            return Ok(await itemInfrastructure.AddItem(name));
        }

        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            ItemService itemInfrastructure = new ItemService(_itemRepository);
            return Ok(await itemInfrastructure.DeleteItem(id));
        }

        [HttpPatch("UpdateItem")]
        public async Task<IActionResult> UpdateItem(int id, string newName)
        {
            ItemService itemInfrastructure = new ItemService(_itemRepository);
            return Ok(await itemInfrastructure.UpdateItem(id, newName));
        }
    }
}
