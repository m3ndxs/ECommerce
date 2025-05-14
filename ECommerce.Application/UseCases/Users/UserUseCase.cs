using Ecommerce.Infrastructure.Data;
using ECommerce.Application.UseCases.Users.Inputs;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.UseCases.Users
{
    public class UserUseCase : IUserUseCase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserUseCase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Domain.Models.Entities.User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public Domain.Models.Entities.User GetId(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public Domain.Models.Entities.User PostUser(AddUserInput input)
        {
            var userEntity = new Domain.Models.Entities.User
            {
                Name = input.Name,
                Email = input.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(input.Password),
                UserType = input.UserType
            };

            var result = _dbContext.Users.Add(userEntity);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Domain.Models.Entities.User PutUser(int id, UpdateUserInput input)
        {
            var user = _dbContext.Users.Find(id);

            user.Name = input.Name;
            user.Email = input.Email;
            user.UserType = input.UserType;

            if (!string.IsNullOrWhiteSpace(input.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(input.Password);
            }

            _dbContext.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null) throw new Exception("Usuário não encontrado!");

            _dbContext.Users.Remove(user);
            var result = _dbContext.SaveChanges();

            return result == 1;
        }
    }
}
