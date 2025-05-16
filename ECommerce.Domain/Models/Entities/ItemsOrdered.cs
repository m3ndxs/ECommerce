namespace ECommerce.Domain.Models.Entities
{
    public class ItemsOrdered
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}