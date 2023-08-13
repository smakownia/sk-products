using MediatR;
using Smakownia.Events;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IEventBus _eventBus;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductsRepository _productsRepository;
    private readonly ICategoriesRepository _categoriesRepository;

    public DeleteCategoryCommandHandler(IEventBus eventBus,
                                        IUnitOfWork unitOfWork,
                                        IProductsRepository productsRepository,
                                        ICategoriesRepository categoriesRepository)
    {
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
        _productsRepository = productsRepository;
        _categoriesRepository = categoriesRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);
        var products = await _productsRepository.GetAllAsync((p) => p.CategoryId == category.Id, cancellationToken);

        _categoriesRepository.Remove(category);

        await _unitOfWork.CommitAsync(cancellationToken);

        foreach (var product in products)
        {
            await _eventBus.PublishAsync(new ProductDeletedEvent(product.Id));
        }

        return Unit.Value;
    }
}
