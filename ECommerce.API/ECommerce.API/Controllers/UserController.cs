using ECommerce.Application.UseCases.Users;
using ECommerce.Application.UseCases.Users.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            return Ok(_userUseCase.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetId(int id)
        { 
            var user = _userUseCase.GetId(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser(AddUserInput input)
        {
            return Ok(_userUseCase.PostUser(input));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutUser(int id, UpdateUserInput input)
        {
            return Ok(_userUseCase.PutUser(id, input));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userUseCase.DeleteUser(id));
        }
    }
}
