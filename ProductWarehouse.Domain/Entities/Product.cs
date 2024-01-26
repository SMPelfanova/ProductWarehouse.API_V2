﻿namespace ProductWarehouse.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Brand Brand { get; set; }
    public Guid BrandId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<ProductGroups> ProductGroups { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
    public ICollection<ProductSize> ProductSizes { get; set; }
}