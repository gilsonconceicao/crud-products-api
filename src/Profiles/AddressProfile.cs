using AutoMapper;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Update;
using Microsoft.AspNetCore.Connections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

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