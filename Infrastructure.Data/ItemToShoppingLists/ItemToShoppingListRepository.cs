using Domain.Core.Abstractions;
using Domain.Interfaces.ItemToShoppingLists;
using Infrastructure.Data.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.ItemToShoppingLists
{
    public class ItemToShoppingListRepository : GenericRepository<ItemToShoppingList>, IItemToShoppingListRepository
    {
        public ItemToShoppingListRepository(ShopContext context) : base(context)
        {
        }

        public async Task<List<ItemToShoppingList>> GetListsByShoppingListId(int id)
        {
            return await _context.ItemToShoppingLists.Where(s => s.ListId == id).ToListAsync();
        }

        public async Task<ItemToShoppingList> UpdateItem(int id, int shopListId, int itemId, int value)
        {
            ItemToShoppingList item = _context.ItemToShoppingLists.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return null;
            item.ListId = shopListId;
            item.ItemId = itemId;
            item.Value = value;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
