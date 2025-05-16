namespace ECommerce.Application.UseCases.Orders.Inputs
{
    public class AddOrderInput
    {
        public int UserId { get; set; }
        public List<AddItemOrderedInput> Items { get; set; }
    }
}
