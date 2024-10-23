using API.BLL.Abstract;
using API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto dto)
        {
            await _productService.CreateProduct(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            await _productService.UpdateProduct(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _productService.GetProducts();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _productService.GetProductById(id);
            return Ok(data);
        }
    }
}