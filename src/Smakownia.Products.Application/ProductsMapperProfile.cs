using AutoMapper;
using Microsoft.Extensions.Configuration;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.ValueObjects;

namespace Smakownia.Products.Application;

public class ProductsMapperProfile : Profile
{
    public ProductsMapperProfile(IConfiguration configuration)
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ImageUrl,
            opt => opt.MapFrom(src => configuration["StaticFilesUrl"] + src.ImageFileName));

        CreateMap<Price, PriceDto>()
            .ConvertUsing(f => new()
            {
                Raw = f.Value,
                Formatted = decimal.Divide(f.Value, 100).ToString("0.00") + "zł"
            });
    }
}
