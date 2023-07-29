using MediatR;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Application.Queries.GetAllCategories;

public sealed record GetAllCategoriesQuery() : IRequest<IEnumerable<Category>>;
