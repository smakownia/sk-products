using MediatR;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Products.Application.Commands.CreateProduct;

public sealed record CreateProductCommand : IRequest<ProductDto>
{
    public CreateProductCommand(Guid categoryId, string name, string? description, long price)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Price = price;
    }

    [Required]
    public Guid CategoryId { get; init; }

    [Required]
    [MinLength(1)]
    public string Name { get; init; }

    public string? Description { get; init; }

    [Required]
    [Range(1, long.MaxValue)]
    public long Price { get; init; }
}
