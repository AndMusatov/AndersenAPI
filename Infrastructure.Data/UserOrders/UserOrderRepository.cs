using Domain.Core.Models;
using Domain.Interfaces.UserOrders;
using Infrastructure.Data.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.UserOrders
{
    public class UserOrderRepository : GenericRepository<UserOrder>, IUserOrdersRepository
    {
        public UserOrderRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<UserOrder>> GetUserOrdersById(string userId)
        {
            return _context.UserOrders.Where(o => o.UserID == userId);
        }
    }
}
