﻿using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<List<Product>> GetProductsAsync()
	{
		try
		{
			var products = _dbContext.Products
				.Where(x => !x.IsDeleted)
				.Include(p => p.Brand)
				.Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
				.Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
				.ToListAsync();

			return products;
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException("No products found.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the products.", ex);
		}
	}

	public Task<Product> GetProductDetailsAsync(Guid id)
	{
		try
		{
			return _dbContext.Products
				.Include(p => p.Brand)
				.Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
				.Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
				.SingleAsync(p => p.Id == id);
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException($"Product with specified id: {id} not found.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the products.", ex);
		}
	}

	public void DeleteProductGroup(Guid productId, Guid groupId)
	{
		try
		{
			var entityToDelete = _dbContext.ProductGroups.Single(x => x.ProductId == productId && x.GroupId == groupId);

			if (entityToDelete != null)
			{
				_dbContext.ProductGroups.Remove(entityToDelete);
			}
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException($"ProductGroup not found for the specified productId: {productId} and groupId: {groupId}.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the product groups.", ex);
		}
	}

	public void UpdateProductSize(ProductSize productSize)
	{
		try
		{
			var entityToUpdate = _dbContext.ProductSizes.Single(x => x.ProductId == productSize.ProductId && x.SizeId == productSize.SizeId);
			if (entityToUpdate != null)
			{
				entityToUpdate.QuantityInStock = productSize.QuantityInStock;
				_dbContext.ProductSizes.Update(entityToUpdate);
			}
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException($"ProductSize not found for the specified productId: {productSize.ProductId} and sizeId: {productSize.SizeId}.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the product sizes.", ex);
		}
	}

	public Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId)
	{
		try
		{
			return _dbContext.ProductSizes
			.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId);
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException($"ProductSize not found for the specified productId: {productId} and sizeId: {sizeId}.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the product sizes.", ex);
		}

	}

	public async Task<int> CheckQuantityInStockAsync(Guid productId, Guid sizeId)
	{
		try
		{
			var productSize = await _dbContext.ProductSizes
						.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId);

			return productSize.QuantityInStock;
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException($"ProductSize not found for the specified productId: {productId} and sizeId: {sizeId}.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the product sizes.", ex);
		}
	}
}