﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductWarehouse.Application.Contracts;
using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Application.Logging;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<ProductsQuery, ProductsFilterDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductsQuery> _validator;
    private readonly ILogger<GetProductsQueryHandler> _logger;

    public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper, IValidator<ProductsQuery> validator, ILogger<GetProductsQueryHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validator = validator;
        _logger = logger;
    }

    public async Task<ProductsFilterDto> Handle(ProductsQuery request, CancellationToken cancellationToken)
    {
        var result = _validator.Validate(request);
        if (!result.IsValid)
        {
            throw new Exceptions.ValidatorException(result.Errors);
        }

        var products = await _productRepository.GetProductsAsync();
        if (products.Count <= 0)
        {
            LoggingMessageDefinitions.LogInformationMessage(_logger, $"No products found for filter: minPrice={request.MinPrice} maxPrice={request.MaxPrice} size={request.Size}");
            return new ProductsFilterDto();
        }

        var productFilter = _mapper.Map<ProductsFilterDto>(products);

        productFilter.Products = productFilter.Products
            .Where(x => (request.MinPrice == 0 || x.Price >= request.MinPrice))
            .Where(x => (request.MaxPrice == 0 || x.Price <= request.MaxPrice))
            .Where(x => (string.IsNullOrEmpty(request.Size) || x.Sizes.Any(s => s.ToLowerInvariant() == request.Size.ToLowerInvariant()))).ToList();

        if (!string.IsNullOrEmpty(request.Highlight))
        {
            foreach (var product in productFilter.Products)
            {
                product.Description = product.Description.HighlightKeywords(request.Highlight);
            }
        }

        return productFilter;
    }
}
