using Domain.Core.Models;
using System.Threading.Tasks;

namespace Services.Interfaces.Items
{
    public interface IItemService
    {
        Task<Item> GetItemAsync(int id);
        Task<Item> AddItemAsync(string name);
        Task<string> DeleteItemAsync(int id);
        Task<string> UpdateItemAsync(int id, string newName);
    }
}
