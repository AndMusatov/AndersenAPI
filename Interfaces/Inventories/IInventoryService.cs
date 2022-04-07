using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Inventories
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryAsync(int id);
        Task<Inventory> AddInventoryAsync(int id, int balance);
        Task<string> DeleteInventoryAsync(int id);
        Task<string> UpdateInventoryAsync(int id, int balance);
    }
}
