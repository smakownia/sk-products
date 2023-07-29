using AutoMapper;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.ValueObjects;

namespace Smakownia.Products.Application;

public class ProductsMapperProfile : Profile
{
    public ProductsMapperProfile()
    {
        CreateMap<Price, long>().ConvertUsing(f => f.Value);
        CreateMap<Product, ProductDto>();
    }
}
