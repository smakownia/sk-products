using MediatR;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly ICategoriesRepository _categoriesRepository;

    public GetCategoryByIdQueryHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
