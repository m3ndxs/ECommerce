namespace ECommerce.Application.Auth
{
    public interface IJwtService
    {
        string GenerateToken(Domain.Models.Entities.User user);
    }
}
