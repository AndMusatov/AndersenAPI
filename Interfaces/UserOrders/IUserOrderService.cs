using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.UserOrders
{
    public interface IUserOrderService
    {
        Task<IEnumerable<UserOrder>> GetUserOrderAsync(string id);
        Task<UserOrder> MakeOrderAsync(string userId, int listId);
    }
}
