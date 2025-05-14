namespace ECommerce.Application.UseCases.Products.Inputs
{
    public class UpdateProductInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
