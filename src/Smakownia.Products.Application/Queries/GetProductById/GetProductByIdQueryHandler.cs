using AutoMapper;
using MediatR;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Application.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public GetProductByIdQueryHandler(IMapper mapper, IProductsRepository productsRepository)
    {
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }
}
