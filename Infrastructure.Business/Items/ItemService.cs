using Domain.Core.Models;
using Domain.Interfaces.Items;
using Services.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Items
{
    public class ItemService : IItemService
    {
        readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _itemRepository.GetById(id);
        }

        public async Task<Item> AddItem(string name)
        {
            Item item = new()
            {
                Name = name
            };
            await _itemRepository.Add(item);
            return item;
        }

        public async Task<string> DeleteItem(int id)
        {
            Item item = await _itemRepository.GetById(id);
            await _itemRepository.Remove(item);
            return "Item was deleted";
        }

        public async Task<string> UpdateItem(int id, string newName)
        {
            await _itemRepository.UpdateItem(id, newName);
            return "Item was updated";
        }
    }
}
