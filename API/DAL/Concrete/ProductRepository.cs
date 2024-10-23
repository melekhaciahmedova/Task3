using API.DAL.Abstract;
using API.DAL.Database;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Concrete
{
    public class ProductRepository(AppDbContext context, IMapper mapper) : IProductRepository
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id)
                 ?? throw new Exception("error"); ;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                                  .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products
                .Include(m => m.Category)
                                 .ToListAsync();
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id)
                ?? throw new Exception("error");
            existingProduct.Name = product.Name;
            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
        }
    }
}