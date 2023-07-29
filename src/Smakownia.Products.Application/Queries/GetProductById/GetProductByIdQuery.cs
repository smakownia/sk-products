using MediatR;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Application.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
