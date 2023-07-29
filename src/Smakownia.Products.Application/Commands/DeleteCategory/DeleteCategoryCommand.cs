using MediatR;

namespace Smakownia.Products.Application.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(Guid Id) : IRequest<Unit>;
