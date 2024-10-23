using API.BLL.Abstract;
using API.DAL.Abstract;
using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.BLL.Concrete
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateProduct(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.CreateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<ProductGetDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductGetDto>(product);
        }

        public async Task<IEnumerable<ProductGetDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductGetDto>>(products);
        }

        public async Task UpdateProduct(int id, ProductUpdateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = id;
            await _productRepository.UpdateProduct(id, product);
        }
    }
}