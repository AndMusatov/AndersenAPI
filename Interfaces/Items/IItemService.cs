using Domain.Core.Models;
using System.Threading.Tasks;

namespace Services.Interfaces.Items
{
    public interface IItemService
    {
        Task<Item> GetItem(int id);
        Task<Item> AddItem(string name);
        Task<string> DeleteItem(int id);
        Task<string> UpdateItem(int id, string newName);
    }
}
