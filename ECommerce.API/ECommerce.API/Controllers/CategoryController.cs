using ECommerce.Application.UseCases.Categories;
using ECommerce.Application.UseCases.Categories.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryUseCase _categoryUseCase;

        public CategoryController(ICategoryUseCase categoryUseCase)
        { 
            _categoryUseCase = categoryUseCase;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryUseCase.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCategoryId(int id) 
        {
            var category = _categoryUseCase.GetId(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public IActionResult PostCatetory(AddCategoryInput input)
        {
            return Ok(_categoryUseCase.PostCategory(input));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutCategory(int id, UpdateCategoryInput input) 
        {
            return Ok(_categoryUseCase.PutCategory(id, input));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategory(int id) 
        {
            return Ok(_categoryUseCase.DeleteCategory(id));
        }
    }
}
