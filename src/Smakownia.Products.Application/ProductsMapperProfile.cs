using AutoMapper;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.ValueObjects;

namespace Smakownia.Products.Application;

public class ProductsMapperProfile : Profile
{
    public ProductsMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Price, PriceDto>()
            .ConvertUsing(f => new()
            {
                Raw = f.Value,
                Formatted = decimal.Divide(f.Value, 100).ToString("0.00") + "zł"
            });
    }
}
