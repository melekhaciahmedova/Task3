using API.DTO;
using API.Entities;

namespace API.BLL.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto dto);
    }
}