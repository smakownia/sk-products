using MediatR;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoriesRepository _categoriesRepository;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoriesRepository categoriesRepository)
    {
        _unitOfWork = unitOfWork;
        _categoriesRepository = categoriesRepository;
    }

    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);

        _categoriesRepository.Add(category);

        await _unitOfWork.CommitAsync(cancellationToken);

        return category;
    }
}
