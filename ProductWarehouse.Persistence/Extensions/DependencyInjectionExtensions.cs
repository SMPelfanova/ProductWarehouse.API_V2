﻿using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.Repositories;

namespace ProductWarehouse.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}