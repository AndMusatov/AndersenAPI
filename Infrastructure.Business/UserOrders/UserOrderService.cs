using Domain.Core.Abstractions;
using Domain.Core.Models;
using Domain.Interfaces.IInventory;
using Domain.Interfaces.Items;
using Domain.Interfaces.ItemToShoppingLists;
using Domain.Interfaces.UserOrders;
using Services.Interfaces.UserOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.UserOrders
{
    public class UserOrderService : IUserOrderService
    {
        private readonly IUserOrdersRepository _userOrderRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IItemToShoppingListRepository _itemToShoppingListRepository;

        private const string DeletedSatus = "Deleted";
        private const string UpdatedSatus = "Updated";

        public UserOrderService(IUserOrdersRepository userOrderRepository, 
            IInventoryRepository inventoryRepository, 
            IItemToShoppingListRepository itemToShoppingList)
        {
            _userOrderRepository = userOrderRepository;
            _inventoryRepository = inventoryRepository;
            _itemToShoppingListRepository = itemToShoppingList;
        }

        public async Task<IEnumerable<UserOrder>> GetUserOrderAsync(string userId)
        {
            var orders = _userOrderRepository.GetUserOrdersById(userId).Result;

            return orders;
        }

        public async Task<UserOrder> MakeOrderAsync(string userId, int listId)
        {
            var order = new UserOrder()
            {
                UserID = userId,
                ShoppingListId = listId,
                OrderDateTime = DateTime.Now
            };

            var itemToShoppingLists = await _itemToShoppingListRepository.GetListsByShoppingListIdAsync(listId);

            foreach (var item in itemToShoppingLists)
            {
                var itemBalance = await _inventoryRepository.GetByIdAsync(item.Id);
                var balance = itemBalance.Balance - item.Value;
                await _inventoryRepository.UpdateInventoryBalanceAsync(item.Id, balance);
            }

            await _userOrderRepository.AddAsync(order);
            return order;
        }
    }
}
