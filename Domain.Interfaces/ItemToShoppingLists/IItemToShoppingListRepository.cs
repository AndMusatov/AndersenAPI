using Domain.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Abstractions;

namespace Domain.Interfaces.ItemToShoppingLists
{
    public interface IItemToShoppingListRepository : IGenericRepository<ItemToShoppingList>
    {
        Task<List<ItemToShoppingList>> GetListsByShoppingListIdAsync(int id);

        Task<ItemToShoppingList> UpdateItemAsync(int id, int shopListId, int itemId, int value);
    }
}
