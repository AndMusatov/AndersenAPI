using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Models
{
    public class UserOrder
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ShoppingListId { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
