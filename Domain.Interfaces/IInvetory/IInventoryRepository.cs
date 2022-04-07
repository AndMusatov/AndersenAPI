using Domain.Interfaces.Generic;
using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IInventory
{
    public interface IInventoryRepository : IGenericRepository<Inventory>
    {
        Task UpdateInventoryBalanceAsync(int id, int balance);
    }
}
