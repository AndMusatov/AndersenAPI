using Domain.Core.Models;
using Domain.Interfaces.IShoppingLists;
using Services.Interfaces.ShoppingLists;
using System.Threading.Tasks;

namespace Infrastructure.Business.ShoppingLists
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _repository;
        private const string DeletedStatus = "Deleted";
        private const string UpdatedStatus = "Updated";

        public ShoppingListService(IShoppingListRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShoppingList> GetItemAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ShoppingList> AddItemAsync(string name)
        {
            var item = new ShoppingList
            {
                Title = name
            };
            await _repository.AddAsync(item);
            return item;
        }

        public async Task<string> DeleteItemAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            await _repository.RemoveAsync(item);
            return DeletedStatus;
        }

        public async Task<string> UpdateItemAsync(int id, string newName)
        {
            await _repository.UpdateListAsync(id, newName);
            return UpdatedStatus;
        }
    }
}
