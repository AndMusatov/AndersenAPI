using Domain.Core.Models;
using Domain.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IShoppingLists
{
    public interface IShoppingListRepository : IGenericRepository<ShoppingList>
    {
        Task UpdateList(int id, string newName);
    }
}
