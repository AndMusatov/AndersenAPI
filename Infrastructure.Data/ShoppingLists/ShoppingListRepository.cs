using Domain.Core.Models;
using Domain.Interfaces.IShoppingLists;
using Infrastructure.Data.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.ShoppingLists
{
    public class ShoppingListRepository : GenericRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(ShopContext context) : base(context)
        {
        }

        public async Task UpdateListAsync(int id, string newName)
        {
            _context.ShoppingLists.FirstOrDefault(i => i.Id == id).Title = newName;
            await _context.SaveChangesAsync();
        }
    }
}
