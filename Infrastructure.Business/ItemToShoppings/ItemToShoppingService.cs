using Domain.Core.Abstractions;
using Domain.Core.Forms;
using Domain.Core.Models;
using Domain.Interfaces.IShoppingLists;
using Domain.Interfaces.Items;
using Domain.Interfaces.ItemToShoppingLists;
using Services.Interfaces.ItemToShoppingLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.NewFolder
{
    public class ItemToShoppingService : IItemToShoppingService
    {
        readonly IItemRepository _itemRepository;
        readonly IShoppingListRepository _shopListRepository;
        readonly IItemToShoppingListRepository _itemToShoppingListRepository;

        public ItemToShoppingService(
            IItemRepository itemRepository,
            IShoppingListRepository shopListRepository,
            IItemToShoppingListRepository itemToShoppingListRepository)
        {
            _itemRepository = itemRepository;
            _shopListRepository = shopListRepository;
            _itemToShoppingListRepository = itemToShoppingListRepository;
        }

        public async Task<ListOutputForm> GetList(int listId)
        {
            List<ItemInList> itemInLists = new List<ItemInList>();
            List<ItemToShoppingList> itemToShoppingLists = await _itemToShoppingListRepository.GetListsByShoppingListId(listId);
            foreach (var item in itemToShoppingLists)
            {
                Item itemVar = await _itemRepository.GetById(item.ItemId);
                if (itemVar == null)
                    return null;
                itemInLists.Add(new ItemInList
                {
                    Item = itemVar,
                    Value = item.Value
                });
            }
            ShoppingList list = await _shopListRepository.GetById(listId);
            if (list == null)
                return null;
            ListOutputForm form = new ListOutputForm
            {
                Name = list.Title,
                itemsInLists = itemInLists
            };
            return form;
        }

        public async Task<ItemToShoppingList> AddList(int listId, int itemId, int value)
        {
            ItemToShoppingList item = new()
            {
                ListId = listId,
                ItemId = itemId,
                Value = value
            };

            await _itemToShoppingListRepository.Add(item);

            return item;
        }

        public async Task<ItemToShoppingList> UpdateList(int id, int shopListId, int itemId, int value)
        {
            return await _itemToShoppingListRepository.UpdateItem(id, shopListId, itemId, value);
        }

        public async Task<string> DeleteList(int id)
        {
            ItemToShoppingList item = await _itemToShoppingListRepository.GetById(id);
            await _itemToShoppingListRepository.Remove(item);
            return "Deleted";
        }
    }
}
