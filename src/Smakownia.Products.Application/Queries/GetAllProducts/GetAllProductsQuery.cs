using MediatR;
using Smakownia.Products.Application.Dtos;

namespace Smakownia.Products.Application.Queries.GetAllProducts;

public sealed record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;
