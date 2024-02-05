﻿using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext dbContext):base(dbContext)
    {
    }
}