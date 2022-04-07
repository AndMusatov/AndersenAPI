using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.ItemToShoppingLists;
using Services.Interfaces.ShoppingLists;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IItemToShoppingService _itemToShoppingService;

        public ShoppingListController(IShoppingListService shoppingListService, 
            IItemToShoppingService itemToShoppingService)
        {
            _shoppingListService = shoppingListService;
            _itemToShoppingService = itemToShoppingService;
        }

        [HttpGet("GetShoppingList")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _shoppingListService.GetItemAsync(id));
        }

        [HttpGet("GetItemsInShoppingList")]
        public async Task<IActionResult> GetList(int shoppingListId)
        {
            return Ok(await _itemToShoppingService.GetListAsync(shoppingListId));
        }

        [HttpPost("AddShoppingList")]
        public async Task<IActionResult> AddItem(string name)
        {
            return Ok(await _shoppingListService.AddItemAsync(name));
        }

        [HttpPost("AddItemToShoppingList")]
        public async Task<IActionResult> AddList(int listId, int itemId, int value)
        {
            return Ok(await _itemToShoppingService.AddListAsync(listId, itemId, value));
        }

        [HttpDelete("DeleteShoppingList")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return Ok(await _shoppingListService.DeleteItemAsync(id));
        }

        [HttpDelete("DeleteItemInShoppingList")]
        public async Task<IActionResult> DeleteList(int id)
        {
            return Ok(await _itemToShoppingService.DeleteListAsync(id));
        }

        [HttpPatch("UpdateShoppingList")]
        public async Task<IActionResult> UpdateItem(int id, string newName)
        {
            return Ok(await _shoppingListService.UpdateItemAsync(id, newName));
        }

        [HttpPatch("UpdateItemToShoppingList")]
        public async Task<IActionResult> UpdateList(int id, int shopListId, int itemId, int value)
        {
            return Ok(await _itemToShoppingService.UpdateListAsync(id, shopListId, itemId, value));
        }
    }
}
