﻿using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
    {
    }
}