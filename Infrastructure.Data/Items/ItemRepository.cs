using Domain.Core.Models;
using Domain.Interfaces.Items;
using Infrastructure.Data.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Items
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ShopContext context) : base(context)
        {
        }

        public async Task UpdateItemAsync(int id, string newName)
        {
            _context.Items.FirstOrDefault(i => i.Id == id).Name = newName;
            await _context.SaveChangesAsync();
        }
    }
}
