﻿namespace ProductWarehouse.Application.Models;

public class BasketLineDto
{
	public Guid Id { get; set; }
	public Guid BasketId { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public decimal TotalAmount { get; set; }
	public Guid SizeId { get; set; }
}