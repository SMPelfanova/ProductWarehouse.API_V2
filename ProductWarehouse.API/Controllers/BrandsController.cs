﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
using ProductWarehouse.Application.Features.Queries.Brands.GetBrand;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing brands related operations.
/// </summary>
public class BrandsController : BaseController
{
	/// <summary>
	/// Get all brands.
	/// </summary>
	/// <returns>A list of all brands.</returns>
	[HttpGet]
	public async Task<IActionResult> GetBrands(
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetAllBrandsQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}

	/// <summary>
	/// Get a brand by ID.
	/// </summary>
	/// <param name="request">The ID of the brand to retrieve.</param>
	/// <returns>The brand with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetBrand(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetBrandQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}
}