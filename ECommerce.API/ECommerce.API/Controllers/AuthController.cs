using BCrypt.Net;
using Ecommerce.Infrastructure.Data;
using ECommerce.Application.Auth;
using ECommerce.Application.Auth.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IJwtService _jwtService;

        public AuthController(ApplicationDbContext dbContext, IJwtService jwtService    )
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginInput input)
        {
            var user  = _dbContext.Users.FirstOrDefault(u => u.Email == input.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(input.Password, user.Password))
                return Unauthorized("Usuário ou senha inválidos.");

            var token = _jwtService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
