using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Balance { get; set; }
    }
}
