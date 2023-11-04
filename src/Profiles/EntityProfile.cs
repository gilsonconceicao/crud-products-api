using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Models;

namespace crud_products_api.src.Profiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, Entity>().ReverseMap();
        }
    }
}