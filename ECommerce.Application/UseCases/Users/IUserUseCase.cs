using ECommerce.Application.UseCases.Users.Inputs;

namespace ECommerce.Application.UseCases.Users
{
    public interface IUserUseCase
    {
        List<Domain.Models.Entities.User> GetAll();
        Domain.Models.Entities.User GetId(int id);
        Domain.Models.Entities.User PostUser(AddUserInput input);
        Domain.Models.Entities.User PutUser(int id, UpdateUserInput input);
        bool DeleteUser(int id);
    }
}
