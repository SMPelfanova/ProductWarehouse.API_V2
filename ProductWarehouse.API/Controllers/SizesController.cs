﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Sizes;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-sizes-related operations.
/// </summary>
public class SizesController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetSizes([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllSizesQuery());
        if (result == null || !result.Any())
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSize([FromServices] IMediator mediator, Guid id)
    {
        var size = await mediator.Send(new GetSizeQuery(id));

        if (size == null)
        {
            return NotFound();
        }

        return Ok(size);
    }

}
