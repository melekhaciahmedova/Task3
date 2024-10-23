using API.DTO;
using API.Entities;

namespace API.BLL.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductGetDto>> GetProducts();
        Task<ProductGetDto> GetProductById(int id);
        Task CreateProduct(ProductCreateDto dto);
        Task UpdateProduct(int id, ProductUpdateDto product);
        Task DeleteProduct(int id);
    }
}