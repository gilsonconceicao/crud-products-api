
using AutoMapper;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;

namespace crud_products_api.src.Profiles;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadModel>()
            .ReverseMap();
        CreateMap<Task<List<Product>>, Task<List<ProductReadModel>>>()
            .ReverseMap();
        CreateMap<ProductCreateModel, Product>();
    }
}
