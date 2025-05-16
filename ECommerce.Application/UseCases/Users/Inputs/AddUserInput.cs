using ECommerce.Domain.Enums;

namespace ECommerce.Application.UseCases.Users.Inputs
{
    public class AddUserInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
