﻿using AutoMapper;
using MediatR;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.Repositories;
using Smakownia.Products.Domain.ValueObjects;

namespace Smakownia.Products.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IProductsRepository _productsRepository;

    public CreateProductCommandHandler(IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       ICategoriesRepository categoriesRepository,
                                       IProductsRepository productsRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _categoriesRepository = categoriesRepository;
        _productsRepository = productsRepository;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var price = Price.Create(request.Price);
        var product = new Product(request.CategoryId, request.Name, request.Description, price);

        await _categoriesRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        _productsRepository.Add(product);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }
}
