using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}