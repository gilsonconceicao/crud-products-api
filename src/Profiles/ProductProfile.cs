
using AutoMapper;
using crud_products_api.src.Enums;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;
using crud_products_api.src.Models.Update;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace crud_products_api.src.Profiles;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadModel>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.CategoryDisplay, opt => opt.MapFrom(src => EnumHelper<Category>.GetDisplayValue(src.Category)))
            .ForMember(dest => dest.TypeOfCalculationDisplay, opt => opt.MapFrom(src => EnumHelper<AbsoluePercentage>.GetDisplayValue(src.TypeOfCalculation)))
            .ReverseMap();
        CreateMap<Task<List<Product>>, Task<List<ProductReadModel>>>()
            .ReverseMap();
        CreateMap<ProductCreateModel, Product>();
        CreateMap<ProductUpdateModel, Product>();
    }
}
