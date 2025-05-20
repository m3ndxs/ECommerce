using ECommerce.Application.UseCases.Products;
using ECommerce.Application.UseCases.Products.Inputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUseCase _productUseCase;

        public ProductController(IProductUseCase productUseCase)
        {
            _productUseCase = productUseCase;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productUseCase.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductId(int id)
        {
            var product = _productUseCase.GetId(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [Authorize(Roles = "Vendedor")]
        [HttpPost]
        public IActionResult PostProduct(AddProductInput input)
        {
            return Ok(_productUseCase.PostProduct(input));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutProduct(int id, UpdateProductInput input)
        {
            return Ok(_productUseCase.PutProduct(id, input));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct(int id) 
        {
            return Ok(_productUseCase.DeleteProduct(id));
        }
    }
}
