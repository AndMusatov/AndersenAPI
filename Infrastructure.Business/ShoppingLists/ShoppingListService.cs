using Domain.Core.Models;
using Domain.Interfaces.IShoppingLists;
using Services.Interfaces.ShoppingLists;
using System.Threading.Tasks;

namespace Infrastructure.Business.ShoppingLists
{
    public class ShoppingListService : IShoppingListService
    {
        readonly IShoppingListRepository _repository;
        public ShoppingListService(IShoppingListRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShoppingList> GetItem(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ShoppingList> AddItem(string name)
        {
            ShoppingList item = new ShoppingList
            {
                Title = name
            };
            await _repository.Add(item);
            return item;
        }

        public async Task<string> DeleteItem(int id)
        {
            var item = await _repository.GetById(id);
            await _repository.Remove(item);
            return "ShoppingList was deleted";
        }

        public async Task<string> UpdateItem(int id, string newName)
        {
            await _repository.UpdateList(id, newName);
            return "ShoppingList was updated";
        }
    }
}
