using MediatR;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Application.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<Category>;
