﻿using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext):base(dbContext)
    {
    }
}