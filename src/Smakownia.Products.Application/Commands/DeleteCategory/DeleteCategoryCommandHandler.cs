using MediatR;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoriesRepository _categoriesRepository;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoriesRepository categoriesRepository)
    {
        _unitOfWork = unitOfWork;
        _categoriesRepository = categoriesRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);

        _categoriesRepository.Remove(category);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}
