using Domain.Core.Models;
using Domain.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserOrders
{
    public interface IUserOrdersRepository : IGenericRepository<UserOrder>
    {
        Task<IEnumerable<UserOrder>> GetUserOrdersById(string userId);
    }
}
