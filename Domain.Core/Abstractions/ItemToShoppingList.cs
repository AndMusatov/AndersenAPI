namespace Domain.Core.Abstractions
{
    public class ItemToShoppingList
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public int Value { get; set; }
    }
}
