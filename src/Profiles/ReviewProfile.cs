using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_products_api.src.Models;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Models.Read;

namespace crud_products_api.src.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewReadModel, Review>()
                .ReverseMap();
            CreateMap<ReviewCreateModel, Review>()
                .ReverseMap();
        }
    }
}