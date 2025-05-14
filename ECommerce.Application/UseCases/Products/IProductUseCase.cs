using ECommerce.Application.UseCases.Products.Inputs;

namespace ECommerce.Application.UseCases.Products
{
    public interface IProductUseCase
    {
        List<Domain.Models.Entities.Product> GetAll();
        Domain.Models.Entities.Product GetId(int id);
        Domain.Models.Entities.Product PostProduct(AddProductInput input);
        Domain.Models.Entities.Product PutProduct(int id, UpdateProductInput input);
        bool DeleteProduct(int id);
    }
}
