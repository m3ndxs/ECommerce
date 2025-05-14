namespace ECommerce.Domain.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal TotalValue { get; set; }

        public ICollection<ItemsOrdered> ItemsOrdereds { get; set; }
    }
}