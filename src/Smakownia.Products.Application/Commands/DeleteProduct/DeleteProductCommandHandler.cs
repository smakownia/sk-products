using MediatR;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;
using Smakownia.Events;

namespace Smakownia.Products.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IEventBus _eventBus;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductsRepository _productsRepository;

    public DeleteProductCommandHandler(IEventBus eventBus,
                                       IUnitOfWork unitOfWork,
                                       IProductsRepository productsRepository)
    {
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
        _productsRepository = productsRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id, cancellationToken);

        _productsRepository.Remove(product);

        await _unitOfWork.CommitAsync(cancellationToken);

        await _eventBus.PublishAsync(new ProductDeletedEvent(product.Id));

        return Unit.Value;
    }
}
