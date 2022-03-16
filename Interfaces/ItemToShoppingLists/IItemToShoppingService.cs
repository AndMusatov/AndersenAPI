using Domain.Core.Abstractions;
using Domain.Core.Forms;
using System.Threading.Tasks;

namespace Services.Interfaces.ItemToShoppingLists
{
    public interface IItemToShoppingService
    {
        Task<ListOutputForm> GetList(int listId);
        Task<ItemToShoppingList> AddList(int listId, int itemId, int value);
        Task<ItemToShoppingList> UpdateList(int id, int shopListId, int itemId, int value);
        Task<string> DeleteList(int id);
    }
}
