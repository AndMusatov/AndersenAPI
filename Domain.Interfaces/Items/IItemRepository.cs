using Domain.Core.Models;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Items
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task UpdateItem(int id, string newName);
    }
}
