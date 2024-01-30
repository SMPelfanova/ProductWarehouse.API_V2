﻿namespace ProductWarehouse.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    ISizeRepository Sizes { get; }
    IOrderStatusRepository OrdersStatuses { get; }
    IGroupRepository Group { get; }
    IOrderRepository Orders { get; }
    IBrandRepository Brands { get; }
    Task<int> SaveChangesAsync();

}
