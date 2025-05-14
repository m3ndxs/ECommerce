using Ecommerce.Infrastructure.Data;
using ECommerce.Application.UseCases.Categories.Inputs;

namespace ECommerce.Application.UseCases.Categories
{
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryUseCase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Domain.Models.Entities.Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Domain.Models.Entities.Category GetId(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public Domain.Models.Entities.Category PostCategory(AddCategoryInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new Exception("Nome da categoria é obrigatório!");

            var existingCategory = _dbContext.Categories.FirstOrDefault(c => c.Name.ToLower() == input.Name.ToLower());

            if (existingCategory != null)
                throw new Exception("Categoria já cadastrada!");

            var categoryEntity = new Domain.Models.Entities.Category { Name = input.Name };
            
            var result = _dbContext.Categories.Add(categoryEntity);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Domain.Models.Entities.Category PutCategory(int id, UpdateCategoryInput input)
        {
            var category = _dbContext.Categories.Find(id);

            category.Name = input.Name;

            _dbContext.SaveChanges();

            return category;
        }

        public bool DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category != null) throw new Exception("Categoria não encontrada!");

            _dbContext.Categories.Remove(category);

            var result = _dbContext.SaveChanges();

            return result == 1;
        }
    }
}
