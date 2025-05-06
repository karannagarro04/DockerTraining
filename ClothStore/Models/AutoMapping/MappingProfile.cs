using System;
using AutoMapper;
using ClothStore.Domain.Brand.Models;

namespace ClothStore.Models.AutoMapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, Brands>().ReverseMap();
    }
}
