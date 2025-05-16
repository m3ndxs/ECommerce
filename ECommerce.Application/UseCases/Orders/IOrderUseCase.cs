using ECommerce.Application.UseCases.Orders.Inputs;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.UseCases.Orders
{
    public interface IOrderUseCase
    {
        List<Domain.Models.Entities.Order> GetAll();
        Domain.Models.Entities.Order GetId(int id);
        Domain.Models.Entities.Order PostOrder(AddOrderInput input);
        Domain.Models.Entities.Order UpdateStatus(int id, OrderStatus status);
        bool DeleteOrder(int id);
    }
}
