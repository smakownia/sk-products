using AutoMapper;
using MediatR;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public GetAllProductsQueryHandler(IMapper mapper, IProductsRepository productsRepository)
    {
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
