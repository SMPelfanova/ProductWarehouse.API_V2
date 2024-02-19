﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Requests.Product.Group;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
using ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product groups related operations.
/// </summary>
[Route("api/products/{id:guid}/groups")]
public class ProductGroupsController : BaseController
{
	/// <summary>
	/// Retrieves all product groups for a specified product.
	/// </summary>
	/// <param name="request">The ID of the product.</param>
	/// <returns>A list of product groups associated with the specified product.</returns>
	[HttpGet]
	public async Task<IActionResult> GetProductGroups(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetProductGroupsQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}

	/// <summary>
	/// Creates a new product group for a specified product.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <param name="request">The request containing the group ID.</param>
	/// <returns>The newly created product group.</returns>
	[HttpPost]
	public async Task<IActionResult> CreateProductGroup(
		Guid id,
		[FromBody] CreateProductGroupRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var command = mapper.Map<CreateProductGroupCommand>(request);
		var resultId = await mediator.Send(command);

		return CreatedAtAction(nameof(GetProductGroups), new { id = id }, request);
	}

	/// <summary>
	/// Deletes a product group for a specified product.
	/// </summary>
	/// <param name="request.id">The ID of the product.</param>
	/// <param name="request.groupId">The ID of the group to be deleted.</param>
	/// <returns>No content if the deletion is successful.</returns>
	[HttpDelete("{groupId:guid}")]
	public async Task<IActionResult> DeleteProductGroup(
		[FromRoute] DeleteProductGroupRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<DeleteProductGroupCommand>(request);
		await mediator.Send(command);

		return NoContent();
	}
}