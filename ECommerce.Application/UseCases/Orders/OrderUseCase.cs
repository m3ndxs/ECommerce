using Ecommerce.Infrastructure.Data;
using ECommerce.Application.UseCases.Orders.Inputs;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.UseCases.Orders
{
    public class OrderUseCase : IOrderUseCase
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderUseCase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Domain.Models.Entities.Order> GetAll()
        {
            return _dbContext.Orders
                .Include(p => p.ItemsOrdereds)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public IEnumerable<Domain.Models.Entities.Order> GetByUserId(int userId)
        {
            return _dbContext.Orders
                .Include(p => p.ItemsOrdereds)
                .Where(i => i.UserId == userId)
                .ToList();
        }

        public Domain.Models.Entities.Order GetId(int id)
        {
            return _dbContext.Orders
                .Include(p => p.ItemsOrdereds)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(p => p.Id == id);
        }

        public Domain.Models.Entities.Order PostOrder(int userId, AddOrderInput input) 
        {
            var user = _dbContext.Users.Find(input.UserId);
            if (user == null || user.UserType != Domain.Enums.UserType.Cliente)
                throw new Exception("Usuário inválido para criar pedido.");

            var orderEntity = new Domain.Models.Entities.Order
            {
                UserId = input.UserId,
                ItemsOrdereds = new List<Domain.Models.Entities.ItemsOrdered>(),
                Status = Domain.Enums.OrderStatus.Pending,
                Date = DateTime.UtcNow
            };

            foreach (var item in input.Items)
            { 
                var product = _dbContext.Products.Find(item.ProductId);
                if (product == null)
                    throw new Exception($"Produto ID {item.ProductId} não encontrado!");

                orderEntity.ItemsOrdereds.Add(new Domain.Models.Entities.ItemsOrdered 
                {
                    ProductId = item.ProductId,
                    Amount = item.Amount,
                    UnitPrice = product.Price
                });
            }

            orderEntity.TotalValue = orderEntity.ItemsOrdereds.Sum(i => i.Amount * i.UnitPrice);

            var result = _dbContext.Orders.Add(orderEntity);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Domain.Models.Entities.Order UpdateStatus(int id, Domain.Enums.OrderStatus status)
        {
            var order = _dbContext.Orders.Find(id);
            if (order != null)
                throw new Exception("Pedido não encontrado!");

            order.Status = status;

            _dbContext.SaveChanges();

            return order;
        }

        public bool DeleteOrder(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order != null)
                throw new Exception("Pedido não encontrado!");

            _dbContext.Orders.Remove(order);

            var result = _dbContext.SaveChanges();

            return result == 1;
        }
    }
}
