using Ecommerce.Infrastructure.Data;
using ECommerce.Application.UseCases.Products.Inputs;

namespace ECommerce.Application.UseCases.Products
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductUseCase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Domain.Models.Entities.Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Domain.Models.Entities.Product GetId(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Domain.Models.Entities.Product PostProduct(AddProductInput input)
        {
            var category = _dbContext.Categories.Find(input.CategoryId);
            if (category == null)
                throw new Exception("Categoria não encontrada!");

            var seller = _dbContext.Users.Find(input.SellerId);
            if (seller == null)
                throw new Exception("Vendedor não encontrado!");

            if (seller.UserType != Domain.Enums.UserType.Seller)
                throw new Exception("Apenas usuários do tipo 'Vendedor' podem cadastrar produtos.");

            if (input.Price <= 0)
                throw new Exception("O preço do produto deve ser maior que R$ 0,00");

            var productEntity = new Domain.Models.Entities.Product
            { 
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                CategoryId = input.CategoryId,
                SellerId = input.SellerId
            };

            var result = _dbContext.Products.Add(productEntity);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Domain.Models.Entities.Product PutProduct(int id, UpdateProductInput input)
        {
            var product = _dbContext.Products.Find(id);

            product.Name = input.Name;
            product.Description = input.Description;
            product.Price = input.Price;
            product.CategoryId = input.CategoryId;

            _dbContext.SaveChanges();

            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product != null) throw new Exception("Produto não encontrado");

            _dbContext.Products.Remove(product);

            var result = _dbContext.SaveChanges();

            return result == 1;
        }
    }
}
