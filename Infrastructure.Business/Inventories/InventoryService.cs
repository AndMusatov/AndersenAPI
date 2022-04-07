using Domain.Core.Models;
using Domain.Interfaces.IInventory;
using Services.Interfaces.Inventories;
using System.Threading.Tasks;

namespace Infrastructure.Business.Inventories
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private const string DeletedSatus = "Deleted";
        private const string UpdatedSatus = "Updated";

        public InventoryService(IInventoryRepository itemRepository)
        {
            _inventoryRepository = itemRepository;
        }

        public async Task<Inventory> GetInventoryAsync(int id)
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        public async Task<Inventory> AddInventoryAsync(int id, int balance)
        {
            var item = new Inventory()
            {
                ItemId = id,
                Balance = balance
            };
            await _inventoryRepository.AddAsync(item);
            return item;
        }

        public async Task<string> DeleteInventoryAsync(int id)
        {
            var item = await _inventoryRepository.GetByIdAsync(id);
            await _inventoryRepository.RemoveAsync(item);
            return DeletedSatus;
        }

        public async Task<string> UpdateInventoryAsync(int id, int balance)
        {
            await _inventoryRepository.UpdateInventoryBalanceAsync(id, balance);
            return UpdatedSatus;
        }
    }
}
