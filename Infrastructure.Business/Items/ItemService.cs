using Domain.Core.Models;
using Domain.Interfaces.Items;
using Services.Interfaces.Items;
using System.Threading.Tasks;

namespace Infrastructure.Business.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private const string DeletedSatus = "Deleted";
        private const string UpdatedSatus = "Updated";

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task<Item> AddItemAsync(string name)
        {
            var item = new Item()
            {
                Name = name
            };
            await _itemRepository.AddAsync(item);
            return item;
        }

        public async Task<string> DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            await _itemRepository.RemoveAsync(item);
            return DeletedSatus;
        }

        public async Task<string> UpdateItemAsync(int id, string newName)
        {
            await _itemRepository.UpdateItemAsync(id, newName);
            return UpdatedSatus;
        }
    }
}
