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
        private readonly IItemRepository _itemRepository;
        private readonly IShoppingListRepository _shopListRepository;
        private readonly IItemToShoppingListRepository _itemToShoppingListRepository;

        private const string DeletedStatus = "Deleted";

        public ItemToShoppingService(
            IItemRepository itemRepository,
            IShoppingListRepository shopListRepository,
            IItemToShoppingListRepository itemToShoppingListRepository)
        {
            _itemRepository = itemRepository;
            _shopListRepository = shopListRepository;
            _itemToShoppingListRepository = itemToShoppingListRepository;
        }

        public async Task<ListOutputForm> GetListAsync(int listId)
        {
            var itemInLists = new List<ItemInList>();
            var itemToShoppingLists = await _itemToShoppingListRepository.GetListsByShoppingListIdAsync(listId);

            foreach (var item in itemToShoppingLists)
            {
                var itemVar = await _itemRepository.GetByIdAsync(item.ItemId);
                if (itemVar == null)
                {
                    return null;
                }
                itemInLists.Add(new ItemInList
                {
                    Item = itemVar,
                    Value = item.Value
                });
            }

            var list = await _shopListRepository.GetByIdAsync(listId);

            if (list == null)
            {
                return null;
            }

            var form = new ListOutputForm
            {
                Name = list.Title,
                ItemsInLists = itemInLists
            };

            return form;
        }

        public async Task<ItemToShoppingList> AddListAsync(int listId, int itemId, int value)
        {
            var item = new ItemToShoppingList()
            {
                ListId = listId,
                ItemId = itemId,
                Value = value
            };

            await _itemToShoppingListRepository.AddAsync(item);

            return item;
        }

        public async Task<ItemToShoppingList> UpdateListAsync(int id, int shopListId, int itemId, int value)
        {
            return await _itemToShoppingListRepository.UpdateItemAsync(id, shopListId, itemId, value);
        }

        public async Task<string> DeleteListAsync(int id)
        {
            var item = await _itemToShoppingListRepository.GetByIdAsync(id);
            await _itemToShoppingListRepository.RemoveAsync(item);
            return DeletedStatus;
        }
    }
}
