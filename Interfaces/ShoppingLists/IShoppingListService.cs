using Domain.Core.Models;
using System.Threading.Tasks;

namespace Services.Interfaces.ShoppingLists
{
    public interface IShoppingListService
    {
        Task<ShoppingList> GetItemAsync(int id);
        Task<ShoppingList> AddItemAsync(string name);
        Task<string> DeleteItemAsync(int id);
        Task<string> UpdateItemAsync(int id, string newName);
    }
}
