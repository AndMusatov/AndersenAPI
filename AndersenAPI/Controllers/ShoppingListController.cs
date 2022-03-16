using Domain.Interfaces.IShoppingLists;
using Domain.Interfaces.Items;
using Domain.Interfaces.ItemToShoppingLists;
using Infrastructure.Business.NewFolder;
using Infrastructure.Business.ShoppingLists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class ShoppingListController : Controller
    {
        readonly IItemRepository _itemRepository;
        readonly IShoppingListRepository _shopListRepository;
        readonly IItemToShoppingListRepository _itemToShoppingListRepository;
        public ShoppingListController(IShoppingListRepository repository, IItemRepository itemRepository, IItemToShoppingListRepository itemToShoppingListRepository)
        {
            _itemRepository = itemRepository;
            _shopListRepository = repository;
            _itemToShoppingListRepository = itemToShoppingListRepository;
        }

        [HttpGet("GetShoppingList")]
        public async Task<IActionResult> GetItem(int id)
        {
            ShoppingListService shoppingListInfrastructure = new ShoppingListService(_shopListRepository);
            return Ok(await shoppingListInfrastructure.GetItem(id));
        }

        [HttpGet("GetItemsInShoppingList")]
        public async Task<IActionResult> GetList(int shoppingListId)
        {
            ItemToShoppingService listInfrastructure =
                new ItemToShoppingService(_itemRepository, _shopListRepository, _itemToShoppingListRepository);
            return Ok(await listInfrastructure.GetList(shoppingListId));
        }

        [HttpPost("AddShoppingList")]
        public async Task<IActionResult> AddItem(string name)
        {
            ShoppingListService shoppingListInfrastructure = new ShoppingListService(_shopListRepository);
            return Ok(await shoppingListInfrastructure.AddItem(name));
        }

        [HttpPost("AddItemToShoppingList")]
        public async Task<IActionResult> AddList(int listId, int itemId, int value)
        {

            ItemToShoppingService listInfrastructure =
                new ItemToShoppingService(_itemRepository, _shopListRepository, _itemToShoppingListRepository);
            return Ok(await listInfrastructure.AddList(listId, itemId, value));
        }

        [HttpDelete("DeleteShoppingList")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            ShoppingListService shoppingListInfrastructure = new ShoppingListService(_shopListRepository);
            return Ok(await shoppingListInfrastructure.DeleteItem(id));
        }

        [HttpDelete("DeleteItemInShoppingList")]
        public async Task<IActionResult> DeleteList(int id)
        {
            ItemToShoppingService listInfrastructure =
                new ItemToShoppingService(_itemRepository, _shopListRepository, _itemToShoppingListRepository);
            return Ok(await listInfrastructure.DeleteList(id));
        }

        [HttpPatch("UpdateShoppingList")]
        public async Task<IActionResult> UpdateItem(int id, string newName)
        {
            ShoppingListService shoppingListInfrastructure = new ShoppingListService(_shopListRepository);
            return Ok(await shoppingListInfrastructure.UpdateItem(id, newName));
        }

        [HttpPatch("UpdateItemToShoppingList")]
        public async Task<IActionResult> UpdateList(int id, int shopListId, int itemId, int value)
        {
            ItemToShoppingService listInfrastructure =
                new ItemToShoppingService(_itemRepository, _shopListRepository, _itemToShoppingListRepository);
            return Ok(await listInfrastructure.UpdateList(id, shopListId, itemId, value));
        }
    }
}
