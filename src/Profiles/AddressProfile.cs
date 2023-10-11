using AutoMapper;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Update;
using Microsoft.AspNetCore.Connections;

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
            CreateMap<AddressUpdateModel, Address>()
                .ReverseMap();
        }
    }
}