﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Queries.GetProduct;
using ProductWarehouse.Application.Features.Queries.GetProducts;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-related operations.
/// </summary>
public class ProductsController : BaseController
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public ProductsController(ILogger<ProductsController> logger, IMediator mediator, IMapper mapper)
         : base(logger, mediator, mapper)
    {
    }

    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>List of products.</returns>
    /// <response code="200">Returns list of products</response>
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult> GetProducts()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());

        var products = _mapper.Map<IEnumerable<ProductResponse>>(result.Products);

        if (products == null || !products.Any())
        {
            return NotFound();
        }

        return Ok(products);
    }

    /// <summary>
    /// Get products based on filter criteria.
    /// </summary>
    /// <param name="productsFilter">Filter criteria.</param>
    /// <returns>Filtered products.</returns>
    /// <response code="200">Returns filtered products</response>
    [HttpGet("filter")]
    [Produces("application/json")]
    public async Task<ActionResult> GetProducts([FromQuery] FilterProductsRequest productsFilter)
    {
        var productsQueryMap = _mapper.Map<GetAllProductsQuery>(productsFilter);

        var result = await _mediator.Send(productsQueryMap);

        var response = _mapper.Map<ProductFilterResponse>(result);

        if (response == null || !response.Products.Any())
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetProducts(Guid id)
    {
        var product = await _mediator.Send(new GetProductQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult>  CreateProduct(CreateProductCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
