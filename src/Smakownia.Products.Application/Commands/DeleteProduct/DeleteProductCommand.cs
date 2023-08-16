using MediatR;

namespace Smakownia.Products.Application.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : IRequest<Unit>;
