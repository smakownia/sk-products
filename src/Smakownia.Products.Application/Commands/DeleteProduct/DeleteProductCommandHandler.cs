using MediatR;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductsRepository _productsRepository;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IProductsRepository productsRepository)
    {
        _unitOfWork = unitOfWork;
        _productsRepository = productsRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id, cancellationToken);

        _productsRepository.Remove(product);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}
