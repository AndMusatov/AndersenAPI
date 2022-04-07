using Domain.Core.Models;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Items
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task UpdateItemAsync(int id, string newName);
    }
}
