using ECommerce.Application.UseCases.Categories.Inputs;

namespace ECommerce.Application.UseCases.Categories
{
    public interface ICategoryUseCase
    {
        List<Domain.Models.Entities.Category> GetAll();
        Domain.Models.Entities.Category GetId(int id);
        Domain.Models.Entities.Category PostCategory(AddCategoryInput input);
        Domain.Models.Entities.Category PutCategory(int id, UpdateCategoryInput input);
        bool DeleteCategory(int id);
    }
}
