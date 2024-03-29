﻿using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IBasketRepository : IRepository<Baskets>
{
	Task<Baskets> GetBasketByUserIdAsync(Guid userId, CancellationToken cancellationToken);
	Task DeleteBasketLinesAsync(Guid userId, CancellationToken cancellationToken);
}