﻿namespace ProductWarehouse.API.Models.Responses.Basket;

public class BasketLineResponse
{
	public Guid Id { get; set; }
	public Guid BasketId { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal TotalAmount { get; set; }
	public Guid SizeId { get; set; }
}