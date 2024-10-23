using API.Entities;

namespace API.DAL.Abstract
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}