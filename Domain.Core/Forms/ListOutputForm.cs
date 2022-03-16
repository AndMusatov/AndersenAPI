using Domain.Core.Abstractions;
using System.Collections.Generic;

namespace Domain.Core.Forms
{
    public class ListOutputForm
    {
        public string Name { get; set; }

        public List<ItemInList> itemsInLists { get; set; }
    }
}
