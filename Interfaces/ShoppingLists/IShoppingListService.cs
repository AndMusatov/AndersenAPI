using Domain.Core.Models;
using System.Threading.Tasks;

namespace Services.Interfaces.ShoppingLists
{
    public interface IShoppingListService
    {
        Task<ShoppingList> GetItem(int id);
        Task<ShoppingList> AddItem(string name);
        Task<string> DeleteItem(int id);
        Task<string> UpdateItem(int id, string newName);
    }
}
