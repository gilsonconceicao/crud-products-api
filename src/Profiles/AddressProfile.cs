using AutoMapper;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;

namespace crud_products_api.src.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressCreateModel, Address>()
                .ReverseMap();
            CreateMap<Address, AddressReadModel>()
                .ReverseMap();
        }
    }
}