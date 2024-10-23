using API.BLL.Abstract;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDto dto)
        {
            await _categoryService.CreateCategoryAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _categoryService.GetAllCategoriesAsync();
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return new JsonResult(data, jsonOptions);
        }
    }
}