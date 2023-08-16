using MediatR;
using Microsoft.AspNetCore.Http;
using Smakownia.Products.Application.Attributes;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Products.Application.Commands.CreateProduct;

public sealed record CreateProductCommand : IRequest<ProductDto>
{
    [Required]
    public Guid CategoryId { get; init; }

    [Required]
    [ImageSignature]
    public IFormFile Image { get; init; }

    [Required]
    [MinLength(1)]
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    [Required]
    [Range(1, long.MaxValue)]
    public long Price { get; init; }
}
