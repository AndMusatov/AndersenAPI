using Domain.Core.Abstractions;
using Domain.Core.Forms;
using System.Threading.Tasks;

namespace Services.Interfaces.ItemToShoppingLists
{
    public interface IItemToShoppingService
    {
        Task<ListOutputForm> GetListAsync(int listId);
        Task<ItemToShoppingList> AddListAsync(int listId, int itemId, int value);
        Task<ItemToShoppingList> UpdateListAsync(int id, int shopListId, int itemId, int value);
        Task<string> DeleteListAsync(int id);
    }
}
