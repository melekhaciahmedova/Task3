using API.BLL.Abstract;
using API.DAL.Abstract;
using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.BLL.Concrete
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            var data = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(data);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
    }
}