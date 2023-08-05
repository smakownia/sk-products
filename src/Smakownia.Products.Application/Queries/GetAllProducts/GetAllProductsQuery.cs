using MediatR;
using Smakownia.Products.Application.Dtos;

namespace Smakownia.Products.Application.Queries.GetAllProducts;

public sealed record GetAllProductsQuery(Guid? CategoryId = default) : IRequest<IEnumerable<ProductDto>>;
