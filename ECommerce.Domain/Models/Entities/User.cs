namespace ECommerce.Domain.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}