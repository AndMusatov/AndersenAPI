using Domain.Core.Models;
using Domain.Interfaces.IInventory;
using Infrastructure.Data.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Inventories
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ShopContext context) : base(context)
        {

        }

        public async Task UpdateInventoryBalanceAsync(int id, int balance)
        {
            _context.Inventory.FirstOrDefault(i => i.Id == id).Balance = balance;
            await _context.SaveChangesAsync();
        }
    }
}
