﻿using Microsoft.AspNetCore.JsonPatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;
using ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
using ProductWarehouse.API.Models.Requests;
using AutoMapper;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.API.Models.Requests.Order;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing orders-related operations.
/// </summary>
public class OrdersController : BaseController
{
    [HttpGet("{userId:long}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetOrders(
        Guid userId,
        [FromServices] IMediator mediator)
    {
        var orders = await mediator.Send(new GetAllOrdersQuery(userId));

        if (orders == null || !orders.Any())
        {
            return NotFound();
        }

        return Ok(orders);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetOrder(
        [FromServices] IMediator mediator,
        Guid id)
    {
        var product = await mediator.Send(new GetOrderQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(
    [FromBody] CreateOrderRequest createOrderRequest,
    [FromServices] IMapper mapper,
    [FromServices] IMediator mediator)
    {
        if (createOrderRequest == null)
        {
            return BadRequest("Request body is null");
        }

        var command = mapper.Map<CreateOrderCommand>(createOrderRequest);
        var orderId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetOrder), new { id = orderId }, createOrderRequest);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateOrder(
        [FromServices] IMediator mediator,
        [FromServices] IMapper mapper,
        Guid id,
        [FromBody] JsonPatchDocument<UpdateOrderRequest> patchDocument)
    {
        var command = mapper.Map<JsonPatchDocument<PartialUpdateOrderRequest>>(patchDocument);
        await mediator.Send(new PartialUpdateOrderCommand() { Id = id, PatchDocument = command });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(
        [FromServices] IMediator mediator,
        Guid id)
    {
        await mediator.Send(new DeleteOrderCommand(id));

        return NoContent();
    }
}
